using System.Threading.Tasks;

namespace TesteClienteAgenda.Infra.Data.UoW
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}