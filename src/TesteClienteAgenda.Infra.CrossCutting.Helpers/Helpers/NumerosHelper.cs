using System;
using System.Collections.Generic;
using System.Text;

namespace TesteClienteAgenda.Infra.CrossCutting.Helpers.Helpers
{
    public class NumerosHelper:IDisposable
    {
        public static string ApenasNumeros(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
