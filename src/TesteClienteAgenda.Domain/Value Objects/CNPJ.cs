using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TesteClienteAgenda.Infra.CrossCutting.Helpers.Helpers;

namespace TesteClienteAgenda.Domain.Validations
{
    public class CNPJ
    {
        public const int TamanhoCnpj = 14;

        public static bool Validar(string cpnj)
        {
            var cnpjNumeros = NumerosHelper.ApenasNumeros(cpnj);

            if (!TemTamanhoValido(cnpjNumeros)) return false;
            return !TemDigitosRepetidos(cnpjNumeros) && TemDigitosValidos(cnpjNumeros);
        }

        private static bool TemTamanhoValido(string valor)
        {
            return valor.Length == TamanhoCnpj;
        }

        private static bool TemDigitosRepetidos(string valor)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return ((IList) invalidNumbers).Contains(valor);
        }

        private static bool TemDigitosValidos(string valor)
        {
            var number = valor.Substring(0, TamanhoCnpj - 2);
            var firstDigit = string.Empty;
            var secondDigit = string.Empty;

            using (var digitoVerificador = new DigitoVerificadorHelper(number))
            {
                digitoVerificador.ComMultiplicadoresDeAte(2, 9)
                    .Substituindo("0", 10, 11);
                firstDigit = digitoVerificador.CalculaDigito();
                digitoVerificador.AddDigito(firstDigit);
                secondDigit = digitoVerificador.CalculaDigito();
            }

            return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCnpj - 2, 2);
        }
    }
}
