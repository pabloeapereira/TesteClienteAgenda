using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Infra.Data.Context;

namespace TesteClienteAgenda.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IRepositoryChange<TEntity>
        where TEntity : Entity, new()
    {
        protected TesteClienteAgendaDbContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(TesteClienteAgendaDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> Adicionar(TEntity obj)
        {
            var entity = DbSet.Add(obj).Entity;
            await SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosPaginado(int s, int t)
        {
            return await DbSet.Skip(s).Take(t).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual async Task<TEntity> Atualizar(TEntity obj)
        {
            var entity = DbSet.Update(obj).Entity;
            await SaveChanges();
            return entity;
        }

        public virtual async Task Remover(int id)
        {
            var obj = new TEntity {Id = id};
            DbSet.Remove(obj);
            await SaveChanges();
        }
    }
}