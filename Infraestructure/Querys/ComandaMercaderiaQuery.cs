using Application.Interfaces.IQuerys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class ComandaMercaderiaQuery : IComandaMercaderiaQuery
    {
        private readonly AppDbContext _context;
        public ComandaMercaderiaQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ComandaMercaderia>> GetAll()
        {
            return await _context.ComandaMercaderia.ToListAsync();
        }
        public async Task<ComandaMercaderia> GetById(int id)
        {
            return await _context.ComandaMercaderia.FindAsync(id);
        }
    }
}
