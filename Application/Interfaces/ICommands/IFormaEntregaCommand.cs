using Domain.Entities;

namespace Application.Interfaces.ICommands
{
    public interface IFormaEntregaCommand
    {
        Task Insert(FormaEntrega formaEntrega);
        Task Update(FormaEntrega formaEntrega);
        Task Delete(int id);
    }
}
