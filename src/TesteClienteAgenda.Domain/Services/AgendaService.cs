using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Interfaces.Notifications;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Interfaces.Services;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Services
{
    public class AgendaService : BaseService, IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(INotificador notificador, IAgendaRepository agendaRepository) : base(notificador)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<IEnumerable<Agenda>> ObterPorCliente(int idCliente)
        {
            return await _agendaRepository.ObterPorCliente(idCliente);
        }

        public async Task<ICollection<Agenda>> AplicarTaxa(int idCliente, decimal taxa)
        {
            var agendas = await ObterPorCliente(idCliente);

            var agendasReturn = new List<Agenda>();
            foreach (var agenda in agendas)
            {
                agenda.CalcularValorLiquido(taxa);
                agendasReturn.Add(await _agendaRepository.Atualizar(agenda));
            }

            return agendasReturn;
        }

        public void Dispose()
        {
            _agendaRepository.Dispose();
        }
    }
}
