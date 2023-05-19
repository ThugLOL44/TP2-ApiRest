using Domain.Entities;

namespace Application.Interfaces.IQuerys
{
    public interface ITipoMercaderiaQuery
    {
        Task<IEnumerable<TipoMercaderia>> GetAll();
        Task<TipoMercaderia> GetById(int id);
    }
}
