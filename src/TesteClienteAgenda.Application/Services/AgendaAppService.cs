using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteClienteAgenda.Application.Interfaces;
using TesteClienteAgenda.Application.ViewModels;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Interfaces.Services;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Infra.Data.UoW;

namespace TesteClienteAgenda.Application.Services
{
    public class AgendaAppService : AppService, IAgendaAppService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IAgendaService _agendaService;
        private readonly IMapper _mapper;

        public AgendaAppService(IUnitOfWork uow, IAgendaRepository agendaRepository, IAgendaService agendaService, IMapper mapper) : base(uow)
        {
            _agendaRepository = agendaRepository;
            _agendaService = agendaService;
            _mapper = mapper;
        }
        

        public async Task<IEnumerable<AgendaViewModel>> ObterPorCliente(int idCliente)
        {
            return _mapper.Map<IEnumerable<AgendaViewModel>>(await _agendaService.ObterPorCliente(idCliente));
        }

        public async Task<ICollection<AgendaViewModel>> AplicarTaxa(int idCliente, decimal taxa)
        {

            return _mapper.Map<ICollection<AgendaViewModel>>(
                await _agendaService.AplicarTaxa(idCliente, taxa));
        }
        public void Dispose()
        {
            _agendaRepository.Dispose();
            _agendaService.Dispose();
        }
    }
}
