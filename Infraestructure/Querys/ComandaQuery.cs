using Application.Interfaces.IQuerys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class ComandaQuery : IComandaQuery
    {
        private readonly AppDbContext _context;
        public ComandaQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comanda>> GetAll()
        {
            return await _context.Comanda
           .Include(c => c.ComandaMercaderia)
           .ToListAsync();
        }
        public async Task<Comanda> GetById(Guid comandaId)
        {
            return await _context.Comanda
                .Include(c => c.ComandaMercaderia)
                .ThenInclude(cm => cm.Mercaderia)
                .ThenInclude(m => m.TipoMercaderia)
                .Include(c => c.FormaEntrega)
                .FirstOrDefaultAsync(c => c.ComandaId == comandaId);
        }

        public async Task<IEnumerable<Comanda>> GetComandas(DateTime fecha)
        {
            IQueryable<Comanda> comandas = _context.Comanda;
        
            if(fecha != null) 
            {
                comandas = comandas
                    .Where(c => c.Fecha.Date == fecha.Date)
                    .Include(c => c.FormaEntrega)
                    .Include(c => c.ComandaMercaderia)
                        .ThenInclude(cm => cm.Mercaderia.TipoMercaderia);


            }
            
            var result = await comandas.ToListAsync();

            return result;
        }
    }
}
