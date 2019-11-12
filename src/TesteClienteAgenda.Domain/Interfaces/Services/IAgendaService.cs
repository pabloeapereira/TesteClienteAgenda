using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Interfaces.Services
{
    public interface IAgendaService:IDisposable
    {
        Task<IEnumerable<Agenda>> ObterPorCliente(int idCliente);
        Task<ICollection<Agenda>> AplicarTaxa(int idCliente, decimal taxa);
    }
}
