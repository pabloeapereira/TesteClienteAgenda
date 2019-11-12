using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TesteClienteAgenda.Domain.Specifications
{
    public interface IAbstractSpecification<T>
    {
        Task<bool> IsSatisfiedBy(T entity);

        ICollection<string> GetErrors();
    }
}
