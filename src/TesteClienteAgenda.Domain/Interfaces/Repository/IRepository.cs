using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task <TEntity> Adicionar(TEntity obj);
        Task<TEntity> ObterPorId(int id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> ObterTodosPaginado(int s, int t);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}