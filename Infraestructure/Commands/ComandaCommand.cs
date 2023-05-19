using Application.Interfaces.ICommands;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

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


        //public async Task Create(List<CreateComandaRequest> comandaRequest)
        //{
        //    var groupedRequests = comandaRequest.GroupBy(cr => cr.comandaId);

        //    foreach (var group in groupedRequests)
        //    {
        //        Comanda newComanda = new Comanda
        //        {
        //            FormaEntregaId = group.First().formaEntregaId,
        //            Fecha = DateTime.Now,
        //            ComandaMercaderia = new List<ComandaMercaderia>()
        //        };

        //        foreach (var comandaRequests in group)
        //        {
        //            ComandaMercaderia newComandaMercaderia = new ComandaMercaderia
        //            {
        //                MercaderiaId = comandaRequests.mercaderiaId,
        //                Mercaderia = await _context.Mercaderia.FindAsync(comandaRequests.mercaderiaId),
        //                Comanda = newComanda,
        //                ComandaId = comandaRequests.comandaId
        //            };

        //            newComanda.ComandaMercaderia.Add(newComandaMercaderia);
        //            newComanda.PrecioTotal += newComandaMercaderia.Mercaderia.Precio;
        //            _context.ComandaMercaderia.Add(newComandaMercaderia);
        //        }

        //        _context.Comanda.Add(newComanda);
        //    }
        //    _context.SaveChanges();

        //}

        public async Task<Comanda> Create (ComandaRequest comandaRequest) 
        {
            Comanda newComanda = new Comanda
            {
                FormaEntregaId = comandaRequest.formaEntrega,
                Fecha = DateTime.Now,
                ComandaMercaderia = new List<ComandaMercaderia>(),
            };

            _context.Comanda.Add(newComanda);

            List<Mercaderia> mercaderias = await _context.Mercaderia
                .Where(m => comandaRequest.mercaderias.Contains(m.MercaderiaId))
                .ToListAsync();

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

        //public int ComandaMercaderiaId { get; set; }
        //public int MercaderiaId { get; set; }
        //public Guid ComandaId { get; set; }
        //public Mercaderia Mercaderia { get; set; }
        //public Comanda Comanda { get; set; }


        //public Guid ComandaId { get; set; }
        //public int FormaEntregaId { get; set; }
        //public double PrecioTotal { get; set; }
        //public DateTime Fecha { get; set; }
        //public ICollection<ComandaMercaderia> ComandaMercaderia { get; set; }
        //public FormaEntrega FormaEntrega { get; set; }

        //public async Task<Comanda> Create(List<CreateComandaRequest> comandaRequest)
        //{
        //    var mercaderias = await _context.Mercaderia
        //        .Include(m => m.TipoMercaderia) 
        //        .Where(m => comandaRequest.Select(cr => cr.mercaderiaId).Contains(m.MercaderiaId))
        //        .ToListAsync();

        //    var groupedRequests = comandaRequest.GroupBy(cr => cr.comandaId);

        //    Comanda newComanda = null;

        //    foreach (var group in groupedRequests)
        //    {
        //        newComanda = await _context.Comanda
        //            .Include(c => c.FormaEntrega)
        //            .FirstOrDefaultAsync(c => c.FormaEntregaId == group.First().formaEntregaId);


        //            newComanda = new Comanda
        //            {
        //                FormaEntregaId = group.First().formaEntregaId,
        //                Fecha = DateTime.Now,
        //                ComandaMercaderia = new List<ComandaMercaderia>(),
        //                FormaEntrega = await _context.FormaEntrega.FindAsync(group.First().formaEntregaId)
        //            };

        //            _context.Comanda.Add(newComanda);


        //        foreach (var comandaRequests in group)
        //        {
        //            var mercaderia = mercaderias.FirstOrDefault(m => m.MercaderiaId == comandaRequests.mercaderiaId);

        //            ComandaMercaderia newComandaMercaderia = new ComandaMercaderia
        //            {
        //                MercaderiaId = comandaRequests.mercaderiaId,
        //                Mercaderia = mercaderia,
        //                Comanda = newComanda,
        //                ComandaId = comandaRequests.comandaId
        //            };

        //            newComanda.ComandaMercaderia.Add(newComandaMercaderia);
        //            newComanda.PrecioTotal += mercaderia.Precio;
        //            _context.ComandaMercaderia.Add(newComandaMercaderia);
        //        }
        //    }

        //    await _context.SaveChangesAsync();
        //    return newComanda;
        //}

    }
}










