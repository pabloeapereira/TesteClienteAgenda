using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Interfaces.Notifications;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Interfaces.Services;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Domain.Specifications.Clientes;
using TesteClienteAgenda.Domain.Validations.Clientes;

namespace TesteClienteAgenda.Domain.Services
{
    public class ClienteService :BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador):base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            cliente.AtribuirClassificacao();
            cliente.AtribuirQuarentena();

            bool validation = ExecutarValidacao(new ClienteValidation(), cliente);
            if (!validation) return cliente;
            validation = await ExecutarValidacaoSpecification(new ClienteUnicoSpecification(_clienteRepository), cliente);
            if (!validation) return cliente;


            return await _clienteRepository.Adicionar(cliente);
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        { 
            cliente.AtribuirClassificacao();
            cliente.AtribuirQuarentena();

            bool validation = ExecutarValidacao(new ClienteValidation(), cliente);
            if (!validation) return cliente;

            return await _clienteRepository.Atualizar(cliente);
        }

        public async Task Remover(int id)
        {
            await _clienteRepository.Remover(id);
        }

        public async Task<IEnumerable<Cliente>> Filtrar(string cnpj, string razaoSocial, bool statusCliente)
        {
            cnpj = cnpj == null ? string.Empty : cnpj;
            razaoSocial = razaoSocial == null ? string.Empty : razaoSocial;
            return await _clienteRepository.Buscar(c => c.Cnpj.StartsWith(cnpj) && c.RazaoSocial.StartsWith(razaoSocial) && c.StatusCliente == statusCliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}