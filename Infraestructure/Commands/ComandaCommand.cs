using Application.Exceptions;
using Application.Interfaces.ICommands;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infraestructure.Command
{
    public class ComandaCommand : IComandaCommand
    {
        private readonly AppDbContext _context;
        public ComandaCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task Insert(Comanda comanda)
        {

            await _context.Comanda.AddAsync(comanda);

            await _context.SaveChangesAsync();

        }
        public async Task Update(Comanda comanda)
        {
            _context.Entry(comanda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Comanda comanda = await _context.Comanda.FindAsync(id);
            _context.Comanda.Remove(comanda);
            await _context.SaveChangesAsync();
        }

        public async Task<Comanda> Create (ComandaRequest comandaRequest) 
        {
            Comanda newComanda = new Comanda
            {
                FormaEntregaId = comandaRequest.formaEntrega,
                Fecha = DateTime.Now,
                ComandaMercaderia = new List<ComandaMercaderia>(),
            };

            _context.Comanda.Add(newComanda);
            foreach (int mercaderiaId in comandaRequest.mercaderias)
            {
                if (!int.TryParse(mercaderiaId.ToString(), out int _) || mercaderiaId < 1 || mercaderiaId >= _context.Mercaderia.Count())
                {
                    throw new SyntaxErrorException("Almenos una de las mercaderias es invalida");
                }
            }

            List<Mercaderia> mercaderias = await _context.Mercaderia
                .Where(m => comandaRequest.mercaderias.Contains(m.MercaderiaId))
                .ToListAsync();
            if (mercaderias.IsNullOrEmpty())
            {
                throw new SyntaxErrorException("Almenos una de las mercaderias es invalida");
            }
            foreach (Mercaderia mercaderia in mercaderias) 
            {
                ComandaMercaderia newComandaMercaderia = new ComandaMercaderia
                {
                    MercaderiaId = mercaderia.MercaderiaId,
                    ComandaId = newComanda.ComandaId,
                    Mercaderia = mercaderia,
                    Comanda = newComanda
                };
                newComanda.ComandaMercaderia.Add(newComandaMercaderia);
                newComanda.PrecioTotal += mercaderia.Precio;
                _context.ComandaMercaderia.Add(newComandaMercaderia);
            }
            await _context.SaveChangesAsync();
            return newComanda;

        }

    }
}










