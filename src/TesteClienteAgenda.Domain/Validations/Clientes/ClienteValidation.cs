using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Domain.Validations.Clientes
{
    public class ClienteValidation:AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.DataFundacao)
                .LessThan(DateTime.Now).WithMessage("O campo {PropertyName} precisa ser menor que {ComparisonValue}");

            RuleFor(c => c.Capital)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser menor que {ComparisonValue}");

            RuleFor(c => c.Cnpj)
                .Length(14,14).WithMessage("O campo {PropertyName} precisa ter {MinLength} caracteres");

            RuleFor(c => c.Cnpj)
                .Length(3, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            
        }
    }
}
