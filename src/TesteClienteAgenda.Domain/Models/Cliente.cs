using System;
using System.Collections.Generic;
using System.Text;
using TesteClienteAgenda.Infra.CrossCutting.Helpers.Helpers;

namespace TesteClienteAgenda.Domain.Models
{
    public class Cliente: Entity
    {
        public Cliente()
        {
            Agendas = new List<Agenda>();
        }
        public string RazaoSocial { get; set; }
        public DateTime DataFundacao { get; set; }
        public string Cnpj { get; set; }
        public decimal Capital { get; set; }
        public bool Quarentena { get; private set; }
        public bool StatusCliente { get; set; }
        public char Classificacao { get; private set; }

        public ICollection<Agenda> Agendas { get; set; }


        public void AtribuirQuarentena()
        {
            Quarentena = true;
            using (var calculoDataHelper = new CalculoDataHelper(this.DataFundacao, DateTime.Now))
            {
                if (calculoDataHelper.DiferencaMaiorQueUmAno())
                    Quarentena = false;
            }
        }

        public void AtribuirClassificacao()
        {
            if (Capital > 1000000)
                Classificacao = 'A';
            else if (Capital <= 10000)
                Classificacao = 'C';
            else
                Classificacao = 'B';
        }
    }
}
