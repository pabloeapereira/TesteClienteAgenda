using FluentValidation;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Validations.AgenciaValidation
{
    public  class AgendaValidation : AbstractValidator<Agenda>
    {
        public AgendaValidation()
        {
            RuleFor(a => a.NumeroTitulo)
                .Length(3, 60).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.ValorBruto)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser menor que {ComparisonValue}");

            RuleFor(c => c.Cliente)
              .NotNull().WithMessage("O campo {PropertyName} não pode ser nullo");
        }
    }
}