using Application.Exceptions;
using Application.Interfaces.IQuerys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class MercaderiaQuery : IMercaderiaQuery
    {
        private readonly AppDbContext _context;
        public MercaderiaQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Mercaderia>> GetAll()
        {
            return await _context.Mercaderia.ToListAsync();
        }
        public async Task<Mercaderia> GetById(int id)
        {
            var mercaderia = await _context.Mercaderia
                .Include(p => p.TipoMercaderia)
                .FirstOrDefaultAsync(x => x.MercaderiaId == id);
            return mercaderia;
        }
        public async Task<IEnumerable<Mercaderia>> GetMercaderias(int tipo, string? nombre, string orden = "ASC") 
        {
           
            IEnumerable<Mercaderia> mercaderias = _context.Mercaderia
                .Include(m => m.TipoMercaderia);

            if (tipo != 0)
            {
                mercaderias = mercaderias.Where(m => m.TipoMercaderiaId == tipo);
            }


            if (!string.IsNullOrEmpty(nombre))
            {
                mercaderias = mercaderias.Where(m => m.Nombre.ToLower().Contains(nombre));
            }

            if (orden.ToUpper() == "DESC")
            {
                mercaderias = mercaderias.OrderByDescending(m => m.Precio);
            }
            else if(orden.ToUpper() == "ASC")
            {
                mercaderias = mercaderias.OrderBy(m => m.Precio);
            }
            else
            {
                throw new BadRequestException("Orden no valido, Solo se admite ASC o DESC");
            }
            
            mercaderias = mercaderias.ToList();
            return mercaderias;
        }
    }
}
