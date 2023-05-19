﻿using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase
{
    public class ComandaServices : IComandaServices
    {
        private readonly IComandaCommand _comandaCommand;
        private readonly IComandaQuery _comandaQuery;
        private readonly IFormaEntregaQuery _formaEntregaQuery;
        private readonly IMercaderiaQuery _mercaderiaQuery;

        public ComandaServices(IComandaCommand comandaCommand, IComandaQuery comandaQuery, IFormaEntregaQuery formaEntregaQuery, IMercaderiaQuery mercaderiaQuery)
        {
            _comandaCommand = comandaCommand;
            _comandaQuery = comandaQuery;
            _formaEntregaQuery = formaEntregaQuery;
            _mercaderiaQuery = mercaderiaQuery;
        }

        public async Task<IEnumerable<Comanda>> GetAllComandas()
        {
            return await _comandaQuery.GetAll();
        }

        public async Task<ComandaGetResponse> GetComandaById(Guid comandaId)
        {
            var comanda = await _comandaQuery.GetById(comandaId);
            
            
            if (comanda != null)
            {
                ComandaGetResponse comandaGetResponse = new ComandaGetResponse
                {
                    id = comanda.ComandaId,
                    mercaderias = new List<MercaderiaGetResponse>(),
                    formaEntrega = new FormaEntregaResponse
                    {
                        id = comanda.FormaEntregaId,
                        descripcion = comanda.FormaEntrega.Descripcion
                    },
                    total = comanda.PrecioTotal,
                    fecha = comanda.Fecha.ToString()
                };
                foreach (ComandaMercaderia comandaMercaderia in comanda.ComandaMercaderia) 
                {
                    MercaderiaGetResponse mercaderiaGetResponse = new MercaderiaGetResponse
                    {
                        id = comandaMercaderia.MercaderiaId,
                        nombre = comandaMercaderia.Mercaderia.Nombre,
                        precio = comandaMercaderia.Mercaderia.Precio,
                        tipo = new TipoMercaderiaResponse
                        {
                            id = comandaMercaderia.Mercaderia.TipoMercaderiaId,
                            descripcion = comandaMercaderia.Mercaderia.TipoMercaderia.Descripcion
                        },
                        imagen = comandaMercaderia.Mercaderia.Imagen,
                    };
                    comandaGetResponse.mercaderias.Add(mercaderiaGetResponse);

                }
                return comandaGetResponse;
            }
            return null;
        }


        public async Task AddComanda(Comanda comanda)
        {
            await _comandaCommand.Insert(comanda);
        }

        public async Task UpdateComanda(Comanda comanda)
        {
            await _comandaCommand.Update(comanda);
        }

        public async Task DeleteComanda(Guid id)
        {
            await _comandaCommand.Delete(id);
        }

        public async Task<ComandaResponse> CreateComanda(ComandaRequest comandaRequest)
        {
            var result = await _comandaCommand.Create(comandaRequest);
            FormaEntrega formaEntrega = await _formaEntregaQuery.GetById(result.FormaEntregaId);
            ComandaResponse comandaResponse = new ComandaResponse
            {
                id = result.ComandaId,
                mercaderias = new List<ComandaMercaderiaResponse>(),
                formaEntrega = new FormaEntregaResponse
                {
                    id = result.FormaEntregaId,
                    descripcion = formaEntrega.Descripcion
                },
                total = result.PrecioTotal,
                fecha = result.Fecha.ToString()
            };
            foreach (var comandaMercaderia in result.ComandaMercaderia)
            {
                Mercaderia mercaderia = await _mercaderiaQuery.GetById(comandaMercaderia.MercaderiaId);
                comandaResponse.mercaderias.Add(new ComandaMercaderiaResponse
                {
                    id = mercaderia.MercaderiaId,
                    nombre = mercaderia.Nombre,
                    precio = mercaderia.Precio
                });
            }
            return comandaResponse;
        }


        public async Task<IEnumerable<ComandaResponse>> GetComandas(DateTime fecha) 
        {
            var comandas = await _comandaQuery.GetComandas(fecha);

            var comandaResponses = new List<ComandaResponse>();

            if (comandas != null) 
            {
                foreach(Comanda comanda in comandas) 
                {
                    ComandaResponse comandaResponse = new ComandaResponse
                    {
                        id = comanda.ComandaId,
                        mercaderias = new List<ComandaMercaderiaResponse>(),
                        formaEntrega = new FormaEntregaResponse
                        {
                            id = comanda.FormaEntregaId,
                            descripcion = comanda.FormaEntrega.Descripcion
                        },
                        total = comanda.PrecioTotal,
                        fecha = comanda.Fecha.ToString()
                    };
                    foreach (ComandaMercaderia comandaMercaderia in comanda.ComandaMercaderia)
                    {
                        ComandaMercaderiaResponse comandaMercaderiaResponse = new ComandaMercaderiaResponse
                        {
                            id = comandaMercaderia.MercaderiaId,
                            nombre = comandaMercaderia.Mercaderia.Nombre,
                            precio = comandaMercaderia.Mercaderia.Precio,
                        };
                        comandaResponse.mercaderias.Add(comandaMercaderiaResponse);

                    }
                    comandaResponses.Add(comandaResponse);

                }
                return comandaResponses;
            }
            return null;
        }

        //public async Task<IEnumerable<ComandaResponse>> GetComandas(DateTime fecha)
        //{
        //    var comandas = await _comandaQuery.GetComandas(fecha);
        //    var comandaResponses = new List<ComandaResponse>();
        //    if (comandas != null)
        //    {
        //        foreach (var comanda in comandas)
        //        {
        //            var comandaResponse = new ComandaResponse
        //            {
        //                id = comanda.ComandaId,
        //                mercaderias = new List<ComandaMercaderiaResponse>()
        //            };
        //            foreach (var comandaMercaderia in comanda.ComandaMercaderia)
        //            {
        //                var comandaMercaderiaResponse = new ComandaMercaderiaResponse
        //                {
        //                    Mercaderia = new MercaderiaResponse
        //                    {
        //                        id = comandaMercaderia.MercaderiaId,
        //                        tipo = new TipoMercaderiaResponse
        //                        {
        //                            id = comandaMercaderia.Mercaderia.TipoMercaderiaId,
        //                            descripcion = comandaMercaderia.Mercaderia.TipoMercaderia.Descripcion
        //                        },
        //                        nombre = comandaMercaderia.Mercaderia.Nombre,
        //                        precio = comandaMercaderia.Mercaderia.Precio
        //                    }
        //                };
        //                comandaResponse.mercaderias.Add(comandaMercaderiaResponse);
        //            }
        //            comandaResponse.formaEntrega = new FormaEntregaResponse
        //            {
        //                id = comanda.FormaEntrega.FormaEntregaId,
        //                descripcion = comanda.FormaEntrega.Descripcion
        //            };
        //            comandaResponse.total = comanda.PrecioTotal;
        //            comandaResponse.fecha = comanda.Fecha.ToString();
        //            comandaResponses.Add(comandaResponse);

        //        }
        //    }
        //    return comandaResponses;
        //}
    }
}
