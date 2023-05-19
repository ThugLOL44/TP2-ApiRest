using Application.Interfaces.IQuerys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class TipoMercaderiaQuery : ITipoMercaderiaQuery
    {
        private readonly AppDbContext _context;
        public TipoMercaderiaQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoMercaderia>> GetAll()
        {
            return await _context.TipoMercaderia.ToListAsync();
        }
        public async Task<TipoMercaderia> GetById(int id)
        {
            return await _context.TipoMercaderia.FindAsync(id);
        }
    }
}
