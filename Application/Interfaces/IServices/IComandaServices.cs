using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IComandaServices
    {
        Task<ComandaResponse> CreateComanda(ComandaRequest comandaRequest);
        Task<IEnumerable<Comanda>> GetAllComandas();
        Task<ComandaGetResponse> GetComandaById(Guid comandaId);
        Task AddComanda(Comanda comanda);
        Task UpdateComanda(Comanda comanda);
        Task DeleteComanda(Guid id);

        Task<IEnumerable<ComandaResponse>> GetComandas(DateTime fecha);
    }
}
