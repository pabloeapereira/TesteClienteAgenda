using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using TesteClienteAgenda.Application.Attributesc;
using TesteClienteAgenda.Domain.Extensions;

namespace TesteClienteAgenda.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            Agendas = new List<AgendaViewModel>();
        }
        
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [StringLength(200,MinimumLength = 3,ErrorMessage = "Razão Social deve conter entre {2} e  {1} caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data da Fundação")]
        [DisplayName("Data da Fundação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataFundacao { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [DisplayName("CNPJ")]
        //[StringLength(14,MinimumLength = 14,ErrorMessage = "CNPJ deve conter {1} caracteres")]
        [Cnpj(ErrorMessage = "Cnpj inválido")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Preencha o campo Capital")]
        public decimal Capital { get; set; }

        [ScaffoldColumn(false)]
        public bool Quarentena { get; private set; }

        [Required(ErrorMessage = "Preencha o campo de Ativo")]
        [DisplayName("Ativo")]
        public bool StatusCliente { get; set; }

        [ScaffoldColumn(false)]
        public char Classificacao { get; private set; }

        
        public string Status
        {
            get { return StatusCliente ? "Ativo" : "Inativo";}
        }

        public bool ExisteAgenda
        {
            get { return Agendas.Count > 0; }
        }

        public decimal Taxa { get; set; }

        public IFormFile Arquivo { get; set; }

        public string CnpjFormatado
        {
            get { return Cnpj.FormatCnpj(); }
        }

        //public ValidationResult ValidationResult { get; set; }

        public ICollection<AgendaViewModel> Agendas { get; set; }
    }
}
