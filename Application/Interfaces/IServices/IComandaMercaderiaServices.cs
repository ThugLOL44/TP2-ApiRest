using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IComandaMercaderiaServices
    {
        Task<IEnumerable<ComandaMercaderia>> GetAllComandaMercaderia();
        Task<ComandaMercaderia> GetComandaMercaderiaById(int id);
        Task AddComandaMercaderia(ComandaMercaderia comandaMercaderia);
        Task UpdateComandaMercaderia(ComandaMercaderia comandaMercaderia);
        Task DeleteComandaMercaderia(int id);
    }
}
