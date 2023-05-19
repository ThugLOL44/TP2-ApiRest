using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IMercaderiaServices
    {
        Task<IEnumerable<Mercaderia>> GetAllMercaderia();
        Task<IEnumerable<MercaderiaResponse>> GetMercaderias(int tipo, string nombre, string orden);
        Task<MercaderiaResponse> GetMercaderiaById(int id);
        Task AddMercaderia(Mercaderia mercaderia);
        Task<MercaderiaResponse> UpdateMercaderia(int mercaderiaId, MercaderiaRequest request);
        Task<MercaderiaResponse> DeleteMercaderia(int id);
        Task<MercaderiaResponse> CreateMercaderia(MercaderiaRequest request);
    }
}
