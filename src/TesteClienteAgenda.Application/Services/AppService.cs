using TesteClienteAgenda.Infra.Data.UoW;

namespace TesteClienteAgenda.Application.Services
{
    public abstract class AppService
    {
        private readonly IUnitOfWork _uow;

        protected AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void Commit()
        {
            _uow.Commit();
        }
    }
}