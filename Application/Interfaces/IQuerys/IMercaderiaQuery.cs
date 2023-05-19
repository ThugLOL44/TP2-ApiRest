using Domain.Entities;

namespace Application.Interfaces.IQuerys
{
    public interface IMercaderiaQuery
    {
        Task<IEnumerable<Mercaderia>> GetAll();
        Task<IEnumerable<Mercaderia>> GetMercaderias(int tipo, string nombre, string orden = "ASC");
        Task<Mercaderia> GetById(int id);
    }
}
