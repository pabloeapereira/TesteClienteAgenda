using System;

namespace TesteClienteAgenda.Domain.Models
{
    public class Agenda : Entity
    {
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal Taxa { get; set; }
        public DateTime DataLiquidacao { get; set; }
        public string NumeroTitulo { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public void CalcularValorLiquido(decimal taxa)
        {
            Taxa = taxa;
            ValorLiquido = Decimal.Round(ValorBruto * Taxa, 2);
        }
    }
}