using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.UseCase
{
    public class FormaEntregaServices : IFormaEntregaServices
    {
        private readonly IFormaEntregaCommand _formaEntregaCommand;
        private readonly IFormaEntregaQuery _formaEntregaQuery;

        public FormaEntregaServices(IFormaEntregaCommand formaEntregaCommand, IFormaEntregaQuery formaEntregaQuery)
        {
            _formaEntregaCommand = formaEntregaCommand;
            _formaEntregaQuery = formaEntregaQuery;
        }

        public async Task AddFormaEntrega(FormaEntrega formaEntrega)
        {
            await _formaEntregaCommand.Insert(formaEntrega);
        }


        public async Task DeleteFormaEntrega(int id)
        {
            await _formaEntregaCommand.Delete(id);
        }

        public async Task<IEnumerable<FormaEntrega>> GetAllFormaEntrega()
        {
            return await _formaEntregaQuery.GetAll();
        }

        public async Task<FormaEntrega> GetFormaEntregaById(int id)
        {
            return await _formaEntregaQuery.GetById(id);
        }

        public async Task UpdateFormaEntrega(FormaEntrega formaEntrega)
        {
            await _formaEntregaCommand.Update(formaEntrega);
        }
    }
}
