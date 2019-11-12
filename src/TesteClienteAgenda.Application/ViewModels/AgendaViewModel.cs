using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TesteClienteAgenda.Application.ViewModels
{
    public class AgendaViewModel
    {

        [Key] 
        public int Id { get; set; }


        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:p2}")]
        public decimal Taxa { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataLiquidacao { get; set; }
        public string NumeroTitulo { get; set; }
        public int ClienteId { get; set; }
    }
}
