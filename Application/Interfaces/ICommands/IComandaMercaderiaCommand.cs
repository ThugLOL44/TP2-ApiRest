using Domain.Entities;

namespace Application.Interfaces.ICommands
{
    public interface IComandaMercaderiaCommand
    {
        Task Insert(ComandaMercaderia comandaMercaderia);
        Task Update(ComandaMercaderia comandaMercaderia);
        Task Delete(int id);
    }
}
