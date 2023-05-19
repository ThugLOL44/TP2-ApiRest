using Application.Interfaces.ICommands;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Commands
{
    public class ComandaMercaderiaCommand : IComandaMercaderiaCommand
    {
        private readonly AppDbContext _context;
        public ComandaMercaderiaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task Insert(ComandaMercaderia comandaMercaderia)
        {

            await _context.ComandaMercaderia.AddAsync(comandaMercaderia);

            await _context.SaveChangesAsync();

        }
        public async Task Update(ComandaMercaderia comandaMercaderia)
        {
            _context.Entry(comandaMercaderia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            ComandaMercaderia comandaMercaderia = await _context.ComandaMercaderia.FindAsync(id);
            _context.ComandaMercaderia.Remove(comandaMercaderia);
            await _context.SaveChangesAsync();
        }

    }
}
