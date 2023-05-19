using Application.Interfaces.ICommands;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Commands
{
    public class TipoMercaderiaCommand : ITipoMercaderiaCommand
    {
        private readonly AppDbContext _context;
        public TipoMercaderiaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task Insert(TipoMercaderia tipoMercaderia)
        {

            await _context.TipoMercaderia.AddAsync(tipoMercaderia);

            await _context.SaveChangesAsync();

        }
        public async Task Update(TipoMercaderia tipoMercaderia)
        {
            _context.Entry(tipoMercaderia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            TipoMercaderia tipoMercaderia = await _context.TipoMercaderia.FindAsync(id);
            _context.TipoMercaderia.Remove(tipoMercaderia);
            await _context.SaveChangesAsync();
        }

    }
}
