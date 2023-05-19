using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.ICommands
{
    public interface IComandaCommand
    {
        Task<Comanda> Create(ComandaRequest comandaRequest);
        Task Insert(Comanda comanda);
        Task Update(Comanda comanda);
        Task Delete(Guid id);
    }
}
