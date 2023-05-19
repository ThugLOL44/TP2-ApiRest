using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IFormaEntregaServices
    {
        Task<IEnumerable<FormaEntrega>> GetAllFormaEntrega();
        Task<FormaEntrega> GetFormaEntregaById(int id);
        Task AddFormaEntrega(FormaEntrega formaEntrega);
        Task UpdateFormaEntrega(FormaEntrega formaEntrega);
        Task DeleteFormaEntrega(int id);
    }
}
