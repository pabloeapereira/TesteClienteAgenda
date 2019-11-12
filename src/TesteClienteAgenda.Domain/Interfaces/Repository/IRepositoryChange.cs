using System;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Interfaces.Repository
{
    public interface IRepositoryChange<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Atualizar(TEntity obj);
        Task Remover(int id);
    }
}