using Application.Interfaces.IQuerys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class FormaEntregaQuery : IFormaEntregaQuery
    {
        private readonly AppDbContext _context;
        public FormaEntregaQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FormaEntrega>> GetAll()
        {
            return await _context.FormaEntrega.ToListAsync();
        }
        public async Task<FormaEntrega> GetById(int id)
        {
            return await _context.FormaEntrega.FindAsync(id);
        }
    }
}
