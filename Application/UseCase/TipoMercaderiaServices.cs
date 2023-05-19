using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.UseCase
{
    public class TipoMercaderiaServices : ITipoMercaderiaServices
    {
        private readonly ITipoMercaderiaCommand _tipoMercaderiaCommand;
        private readonly ITipoMercaderiaQuery _tipoMercaderiaQuery;
        public TipoMercaderiaServices(ITipoMercaderiaCommand tipoMercaderiaCommand, ITipoMercaderiaQuery tipoMercaderiaQuery)
        {
            _tipoMercaderiaCommand = tipoMercaderiaCommand;
            _tipoMercaderiaQuery = tipoMercaderiaQuery;
        }

        public async Task AddTipoMercaderia(TipoMercaderia tipoMercaderia)
        {
            await _tipoMercaderiaCommand.Insert(tipoMercaderia);
        }

        public async Task DeleteTipoMercaderia(int id)
        {
            await _tipoMercaderiaCommand.Delete(id);
        }

        public async Task<IEnumerable<TipoMercaderia>> GetAllTipoMercaderia()
        {
            return await _tipoMercaderiaQuery.GetAll();
        }

        public async Task<TipoMercaderia> GetTipoMercaderiaById(int id)
        {
            return await _tipoMercaderiaQuery.GetById(id);
        }

        public async Task UpdateTipoMercaderia(TipoMercaderia tipoMercaderia)
        {
            await _tipoMercaderiaCommand.Update(tipoMercaderia);
        }
    }
}
