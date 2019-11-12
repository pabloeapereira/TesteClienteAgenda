using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using TesteClienteAgenda.Domain.Interfaces.Notifications;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Domain.Notifications;
using TesteClienteAgenda.Domain.Specifications;
using TesteClienteAgenda.Domain.Specifications.Clientes;

namespace TesteClienteAgenda.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }


        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }

        protected async Task<bool> ExecutarValidacaoSpecification<TS, TE>(TS specification, TE entidade) where TS : IAbstractSpecification<TE> where TE : Entity
        {
            if (await specification.IsSatisfiedBy(entidade)) return true;

            foreach (var error in specification.GetErrors())
            {
                Notificar(error);
            }

            return false;
        }
    }
}
