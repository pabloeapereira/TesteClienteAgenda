using System.Threading.Tasks;
using TesteClienteAgenda.Infra.Data.Context;

namespace TesteClienteAgenda.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TesteClienteAgendaDbContext _context;

        public UnitOfWork(TesteClienteAgendaDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            _context.SaveChangesAsync();
        }
    }
}