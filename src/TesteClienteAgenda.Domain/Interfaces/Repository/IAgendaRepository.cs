using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Interfaces.Repository
{
    public interface IAgendaRepository : IRepository<Agenda>, IRepositoryChange<Agenda>
    {
        Task<IEnumerable<Agenda>> ObterPorCliente(int idCliente);
    }
}
