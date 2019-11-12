using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Infra.Data.Context;

namespace TesteClienteAgenda.Infra.Data.Repository
{
    public class ClienteRepository: Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TesteClienteAgendaDbContext context) : base(context) { }

        public async Task<Cliente> ObterPorCnpj(string cnpj)
        {
            return await Db.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Cnpj == cnpj);
        }

        public async Task<Cliente> ObterPorRazaoSocial(string razaoSocial)
        {
            return await Db.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.RazaoSocial == razaoSocial);
        }

        public async Task<IEnumerable<Cliente>> ObterAtivos()
        {
            return await Buscar(c => c.StatusCliente);
        }

        public async Task<Cliente> ObterClienteUnico(Cliente cliente)
        {
            
            return await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(c => c.RazaoSocial == cliente.RazaoSocial || c.Cnpj == cliente.Cnpj);
        }
    }
}
