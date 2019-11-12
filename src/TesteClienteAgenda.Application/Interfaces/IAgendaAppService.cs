using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteClienteAgenda.Application.ViewModels;

namespace TesteClienteAgenda.Application.Interfaces
{
    public interface IAgendaAppService:IDisposable
    {
        Task<IEnumerable<AgendaViewModel>> ObterPorCliente(int idCliente);

        Task<ICollection<AgendaViewModel>> AplicarTaxa(int idCliente, decimal taxa);
    }
}
