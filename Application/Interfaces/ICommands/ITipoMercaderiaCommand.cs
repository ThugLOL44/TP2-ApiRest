using Domain.Entities;

namespace Application.Interfaces.ICommands
{
    public interface ITipoMercaderiaCommand
    {
        Task Insert(TipoMercaderia tipomercaderia);
        Task Update(TipoMercaderia tipomercaderia);
        Task Delete(int id);
    }
}
