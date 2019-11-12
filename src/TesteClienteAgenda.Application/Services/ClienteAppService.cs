using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using TesteClienteAgenda.Application.Interfaces;
using TesteClienteAgenda.Application.Utils;
using TesteClienteAgenda.Application.ViewModels;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Interfaces.Services;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Infra.Data.UoW;

namespace TesteClienteAgenda.Application.Services
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteAppService(IUnitOfWork uow, IClienteRepository clienteRepository, IClienteService clienteService, IMapper mapper) : base(uow)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public async Task<ClienteViewModel> Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            cliente = await _clienteService.Adicionar(cliente);

            //if (clienteReturn.ValidationResult.IsValid)
            Commit();

            clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);
            return clienteViewModel;
        }

        public async Task<ClienteViewModel> Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            cliente = await _clienteService.Atualizar(cliente);

            //if (clienteReturn.ValidationResult.IsValid)
            //Commit();

            clienteViewModel = _mapper.Map<ClienteViewModel>(cliente);
            return clienteViewModel;
        }


        public async Task<ClienteViewModel> ObterPorId(int id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterTodos()
        {
            return  _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterAtivos()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterAtivos());
        }

        public async Task<ClienteViewModel> ObterPorCnpj(string cnpj)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorCnpj(cnpj));
        }

        public async Task<ClienteViewModel> ObterPorRazaoSocial(string razaoSocial)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorRazaoSocial(razaoSocial));
        }


        public async Task Remover(int id)
        {
            await _clienteService.Remover(id);
        }

        public async Task<ClienteViewModel> LerArquivoExcelECarregarAgendas(ClienteViewModel clienteViewModel)
        {
            var clienteViewModelEntity = await ObterPorId(clienteViewModel.Id);

            using (var excelFileToAgenda = new ExcelFiletoAgenda(clienteViewModel.Arquivo?.OpenReadStream()))
            {
                var agendas = await excelFileToAgenda.ExcelToAgenda();

                foreach (var agenda in agendas)
                {
                    agenda.ClienteId = clienteViewModel.Id;
                    clienteViewModelEntity.Agendas.Add(agenda);
                }
            }

            
            return await Atualizar(clienteViewModelEntity);
        }

        public async Task<IEnumerable<ClienteViewModel>> Filtrar(string cnpj, string razaoSocial, bool statusCliente)
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteService.Filtrar(cnpj, razaoSocial, statusCliente));
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            _clienteService.Dispose();
        }
    }
}