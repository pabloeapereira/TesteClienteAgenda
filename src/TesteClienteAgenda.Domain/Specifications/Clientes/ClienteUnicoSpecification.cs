using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Interfaces.Notifications;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Specifications.Clientes
{
    public class ClienteUnicoSpecification:AbstractSpecification<Cliente>
    {
        public ClienteUnicoSpecification(IClienteRepository clienteRepository):base(clienteRepository)
        {
        }

        public override async Task<bool> IsSatisfiedBy(Cliente entity)
        {
            var result = await (_repository as IClienteRepository).ObterClienteUnico(entity) == null;
            
            if(!result)
                SetError("Cliente já cadastrado");

            return result;
        }

    }
}
