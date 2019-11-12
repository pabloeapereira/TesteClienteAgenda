using System.Collections.Generic;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>, IRepositoryChange<Cliente>
    {
        Task<Cliente> ObterPorCnpj(string cpf);
        Task<Cliente> ObterPorRazaoSocial(string email);
        Task<IEnumerable<Cliente>> ObterAtivos();

        Task<Cliente> ObterClienteUnico(Cliente cliente);
    }
}