using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.ICommands
{
    public interface IMercaderiaCommand
    {
        Task<Mercaderia> Insert(Mercaderia mercaderia);
        Task<Mercaderia> Update(int mercaderiaId, MercaderiaRequest request);
        Task<Mercaderia> Delete(int id);
    }
}
