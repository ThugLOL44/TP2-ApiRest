using Domain.Entities;

namespace Application.Interfaces.IQuerys
{
    public interface IComandaMercaderiaQuery
    {
        Task<IEnumerable<ComandaMercaderia>> GetAll();
        Task<ComandaMercaderia> GetById(int id);
    }
}
