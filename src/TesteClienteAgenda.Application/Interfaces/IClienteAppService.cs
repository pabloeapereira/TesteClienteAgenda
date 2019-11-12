using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TesteClienteAgenda.Application.ViewModels;

namespace TesteClienteAgenda.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
{
    Task<ClienteViewModel> Adicionar(ClienteViewModel clienteViewModel);
    Task<ClienteViewModel> ObterPorId(int id);
    Task<IEnumerable<ClienteViewModel>> ObterTodos();
    Task<IEnumerable<ClienteViewModel>> ObterAtivos();
    Task<ClienteViewModel> ObterPorCnpj(string cnpj);
    Task<ClienteViewModel> ObterPorRazaoSocial(string razaoSocial);
    Task<ClienteViewModel> Atualizar(ClienteViewModel clienteViewModel);
    Task Remover(int id);

    Task<ClienteViewModel> LerArquivoExcelECarregarAgendas(ClienteViewModel clienteViewModel);

    Task<IEnumerable<ClienteViewModel>> Filtrar(string cnpj, string razaoSocial, bool statusCliente);
}
}
