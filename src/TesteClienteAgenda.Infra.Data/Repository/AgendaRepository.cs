using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Infra.Data.Context;

namespace TesteClienteAgenda.Infra.Data.Repository
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(TesteClienteAgendaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Agenda>> ObterPorCliente(int idCliente)
        {
            return await Buscar(c => c.ClienteId == idCliente);
        }
    }
}
