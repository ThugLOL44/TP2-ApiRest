using Application.Exceptions;
using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Application.UseCase
{
    public class MercaderiaServices : IMercaderiaServices
    {
        private readonly IMercaderiaCommand _mercaderiaCommand;
        private readonly IMercaderiaQuery _mercaderiaQuery;
        private readonly ITipoMercaderiaQuery _tipoMercaderiaQuery;
        private readonly IComandaMercaderiaQuery _comandaMercaderiaQuery;

        public MercaderiaServices(IMercaderiaCommand mercaderiaCommand, IMercaderiaQuery mercaderiaQuery, ITipoMercaderiaQuery tipoMercaderiaQuery, IComandaMercaderiaQuery comandaMercaderiaQuery)
        {
            _mercaderiaCommand = mercaderiaCommand;
            _mercaderiaQuery = mercaderiaQuery;
            _tipoMercaderiaQuery = tipoMercaderiaQuery;
            _comandaMercaderiaQuery = comandaMercaderiaQuery;
        }

        public async Task AddMercaderia(Mercaderia mercaderia)
        {
            await _mercaderiaCommand.Insert(mercaderia);
        }

        public async Task<MercaderiaResponse> CreateMercaderia(MercaderiaRequest request)
        {
            try
            {
                TipoMercaderia tipoMercaderia = await _tipoMercaderiaQuery.GetById(request.tipo);
                if (tipoMercaderia == null)
                {
                    throw new HasConflictException("El tipo de mercaderia especificado no existe en la base de datos");
                }
                IEnumerable<Mercaderia> mercaderias = await _mercaderiaQuery.GetAll();
                foreach (Mercaderia product in mercaderias)
                {
                    if (product.Nombre.ToUpper() == request.nombre.ToUpper())
                    {
                        throw new HasConflictException("Esta mercaderia ya existe.");
                    }
                }

                Mercaderia mercaderia = new Mercaderia
                {
                    Nombre = request.nombre,
                    TipoMercaderiaId = request.tipo,
                    Precio = request.precio,
                    Ingredientes = request.ingredientes,
                    Preparacion = request.preparacion,
                    Imagen = request.imagen
                };
                await _mercaderiaCommand.Insert(mercaderia);
                return new MercaderiaResponse
                {
                    id = mercaderia.MercaderiaId,
                    nombre = mercaderia.Nombre,
                    tipo = new TipoMercaderiaResponse
                    {
                        id = mercaderia.TipoMercaderiaId,
                        descripcion = tipoMercaderia.Descripcion
                    },
                    precio = mercaderia.Precio,
                    ingredientes = mercaderia.Ingredientes,
                    preparacion = mercaderia.Preparacion,
                    imagen = mercaderia.Imagen
                };
            }
            catch(HasConflictException ex) 
            {
                throw new HasConflictException("Error en la operacion: " + ex.Message);
            }
        }



    public async Task<MercaderiaResponse> DeleteMercaderia(int id)
        {
            IEnumerable<ComandaMercaderia> comandaMercaderias = await _comandaMercaderiaQuery.GetAll();
            foreach(ComandaMercaderia comandaMercaderia in comandaMercaderias) 
            {
                if(comandaMercaderia.MercaderiaId == id) 
                {
                    throw new HasConflictException("No se puede eliminar la mercaderia ya que pertenece almenos a una comanda");
                }
            }
            var mercaderia = await _mercaderiaCommand.Delete(id);
            if(mercaderia == null) 
            {
                throw new BadRequestException("No existe mercaderia con ese Id");
            }
            return new MercaderiaResponse
            {
                id = mercaderia.MercaderiaId,
                nombre = mercaderia.Nombre,
                tipo = new TipoMercaderiaResponse
                {
                    id = mercaderia.TipoMercaderia.TipoMercaderiaId,
                    descripcion = mercaderia.TipoMercaderia.Descripcion
                },
                precio = mercaderia.Precio,
                ingredientes = mercaderia.Ingredientes,
                preparacion = mercaderia.Preparacion,
                imagen = mercaderia.Imagen
            };
        }


        public async Task<IEnumerable<Mercaderia>> GetAllMercaderia()
        {
            return await _mercaderiaQuery.GetAll();
        }

        public async Task<MercaderiaResponse> GetMercaderiaById(int id)
        {
            var mercaderia = await _mercaderiaQuery.GetById(id);
            if(mercaderia != null)
            {
                return new MercaderiaResponse
                {
                    id = mercaderia.MercaderiaId,
                    nombre = mercaderia.Nombre,
                    precio = mercaderia.Precio,
                    tipo = new TipoMercaderiaResponse
                    {
                        id = mercaderia.TipoMercaderia.TipoMercaderiaId,
                        descripcion = mercaderia.TipoMercaderia.Descripcion
                    },
                    ingredientes = mercaderia.Ingredientes,
                    preparacion = mercaderia.Preparacion,
                    imagen = mercaderia.Imagen

                };
            }
            throw new NotFoundException("No existe mercaderia con ese Id");
        }

        public async Task<IEnumerable<MercaderiaResponse>> GetMercaderias(int tipo, string nombre, string orden)
        {
            var mercaderias = await _mercaderiaQuery.GetMercaderias(tipo, nombre, orden);
            var mercaderiaResponses = new List<MercaderiaResponse>();
            if (mercaderias != null)
            {
                foreach (var mercaderia in mercaderias) 
                {
                    var mercaderiaResponse = new MercaderiaResponse
                    {
                        id = mercaderia.MercaderiaId,
                        nombre = mercaderia.Nombre,
                        tipo = new TipoMercaderiaResponse
                        {
                            id = mercaderia.TipoMercaderia.TipoMercaderiaId,
                            descripcion = mercaderia.TipoMercaderia.Descripcion
                        },
                        precio = mercaderia.Precio,
                        ingredientes = mercaderia.Ingredientes,
                        preparacion = mercaderia.Preparacion,
                        imagen = mercaderia.Imagen
                    };
                    mercaderiaResponses.Add(mercaderiaResponse);
                  
                }
            }
            return mercaderiaResponses;
        }

        public async Task<MercaderiaResponse> UpdateMercaderia(int mercaderiaId, MercaderiaRequest request)
        {
            await _mercaderiaCommand.Update(mercaderiaId, request);
            Mercaderia mercaderia = await _mercaderiaQuery.GetById(mercaderiaId);
            IEnumerable<Mercaderia> mercaderias = await _mercaderiaQuery.GetAll();

            foreach (Mercaderia product in mercaderias)
            {
                if (product.Nombre.ToUpper() == request.nombre.ToUpper())
                {
                    throw new HasConflictException("El nombre ya es utilizado por otra mercaderia.");
                }
            }

            TipoMercaderia tipoMercaderia = await _tipoMercaderiaQuery.GetById(request.tipo);
            return new MercaderiaResponse
            {
                id = mercaderia.MercaderiaId,
                nombre = mercaderia.Nombre,
                tipo = new TipoMercaderiaResponse
                {
                    id = mercaderia.TipoMercaderiaId,
                    descripcion = tipoMercaderia.Descripcion
                },
                precio = mercaderia.Precio,
                ingredientes = mercaderia.Ingredientes,
                preparacion = mercaderia.Preparacion,
                imagen = mercaderia.Imagen
            };
        }
    }
}
