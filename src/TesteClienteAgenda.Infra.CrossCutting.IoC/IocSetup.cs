using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteClienteAgenda.Application.Interfaces;
using TesteClienteAgenda.Application.Services;
using TesteClienteAgenda.Domain.Interfaces.Notifications;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Interfaces.Services;
using TesteClienteAgenda.Domain.Notifications;
using TesteClienteAgenda.Domain.Services;
using TesteClienteAgenda.Infra.Data.Context;
using TesteClienteAgenda.Infra.Data.Repository;
using TesteClienteAgenda.Infra.Data.UoW;

namespace TesteClienteAgenda.Infra.CrossCutting.IoC
{
    public class IocSetup
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Site

            services.AddScoped<INotificador, Notificador>();
            #endregion
            #region Application

            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IAgendaAppService, AgendaAppService>();
            //Mapper map = new Mapper();
            /*container.RegisterInstance<IMapper>(new Mapper(
                new MapperConfiguration(
                    cfg => { cfg.AddProfile<DomainToViewModelMappingProfile>(); }
                )));*/

            #endregion

            #region Domain

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAgendaService, AgendaService>();

            #endregion

            #region Infra.Data

            services.AddDbContext<TesteClienteAgendaDbContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //container.Register<DbContext,ContextDB>(Lifestyle.Scoped);

            #endregion

            #region Infra.CrossCutting.Helpers

            #endregion
        }
    }
}