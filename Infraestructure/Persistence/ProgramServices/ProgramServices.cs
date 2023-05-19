using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.Services;
using Application.UseCase;
using Infraestructure.Command;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Microsoft.Extensions.DependencyInjection;

namespace TP_Parte_1_Corsiglia_Gonzalo
{
    public class ProgramServices
    {
        private readonly IServiceCollection _services;

        public ProgramServices(IServiceCollection services)
        {
            _services = services;
        }

        public void ConfigureServices()
        {
            _services.AddDbContext<AppDbContext>();
            _services.AddScoped<IComandaCommand, ComandaCommand>();
            _services.AddScoped<IComandaQuery, ComandaQuery>();
            _services.AddScoped<IComandaServices, ComandaServices>();
            _services.AddScoped<IMercaderiaQuery, MercaderiaQuery>();
            _services.AddScoped<IMercaderiaCommand, MercaderiaCommand>();
            _services.AddScoped<IMercaderiaServices, MercaderiaServices>();
            _services.AddScoped<IFormaEntregaQuery, FormaEntregaQuery>();
            _services.AddScoped<IFormaEntregaCommand, FormaEntregaCommand>();
            _services.AddScoped<IFormaEntregaServices, FormaEntregaServices>();
        }
    }
}
