using System.ComponentModel.DataAnnotations;
using TesteClienteAgenda.Domain.Validations;

namespace TesteClienteAgenda.Application.Attributesc
{
    public class CnpjAttribute : ValidationAttribute
    {
        public CnpjAttribute()
        {
            ErrorMessage = "O Valor {0} é inválido para CNPJ";
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value != null)
            {

                var cnpj = value.ToString().Replace(".", "").Replace("/", "").Replace("-", "");

                if (!CnpjValidation.Validar(cnpj))
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }
    }
}