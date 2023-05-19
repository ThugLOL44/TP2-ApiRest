using Application.Interfaces.ICommands;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Commands
{
    public class FormaEntregaCommand : IFormaEntregaCommand
    {
        private readonly AppDbContext _context;
        public FormaEntregaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task Insert(FormaEntrega formaEntrega)
        {

            await _context.FormaEntrega.AddAsync(formaEntrega);

            await _context.SaveChangesAsync();

        }
        public async Task Update(FormaEntrega formaEntrega)
        {
            _context.Entry(formaEntrega).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            FormaEntrega formaEntrega = await _context.FormaEntrega.FindAsync(id);
            _context.FormaEntrega.Remove(formaEntrega);
            await _context.SaveChangesAsync();
        }

    }
}
