using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Task <Cliente> Adicionar(Cliente cliente);

        Task<Cliente> Atualizar(Cliente cliente);
        Task Remover(int id);

        Task<IEnumerable<Cliente>> Filtrar(string cnpj, string razaoSocial, bool statusCliente);
    }
}