using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITipoMercaderiaServices
    {
        Task<IEnumerable<TipoMercaderia>> GetAllTipoMercaderia();
        Task<TipoMercaderia> GetTipoMercaderiaById(int id);
        Task AddTipoMercaderia(TipoMercaderia tipomercaderia);
        Task UpdateTipoMercaderia(TipoMercaderia tipomercaderia);
        Task DeleteTipoMercaderia(int id);
    }
}
