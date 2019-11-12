using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteClienteAgenda.Domain.Interfaces.Repository;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Specifications
{
    public abstract class AbstractSpecification<T>:IAbstractSpecification<T> where T:Entity
    {
        protected IRepository<T> _repository;
        private  ICollection<string> _errors { get; set; }
        public bool IsValid { get; set; }
        public AbstractSpecification(IRepository<T> repository)
        {
            _repository = repository;
            _errors = new List<string>();
        }

        public virtual async Task<bool> IsSatisfiedBy(T entity)
        {
            return true;

        }

        public ICollection<string> GetErrors()
        {
            return _errors;
        }

        public void SetError(string error)
        {
            _errors.Add(error);
        }
    }
}
