using Domain.Entities;

namespace Application.Interfaces.IQuerys
{
    public interface IFormaEntregaQuery
    {
        Task<IEnumerable<FormaEntrega>> GetAll();
        Task<FormaEntrega> GetById(int id);
    }
}
