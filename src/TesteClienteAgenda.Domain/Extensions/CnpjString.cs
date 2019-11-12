using System;


namespace TesteClienteAgenda.Domain.Extensions
{
    public static class CnpjString
    {
        public static string FormatCnpj(this string text)
        {
            if (text == null)
                return null;
            return Convert.ToUInt64(text).ToString(@"00\.000\.000\/0000\-00");

        }
    }
}