using Domain.Entities;

namespace Application.Interfaces.IQuerys
{
    public interface IComandaQuery
    {
        Task<IEnumerable<Comanda>> GetAll();
        Task<Comanda> GetById(Guid id);
        Task<IEnumerable<Comanda>> GetComandas(DateTime fecha);
    }
}
