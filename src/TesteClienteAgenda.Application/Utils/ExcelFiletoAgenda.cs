using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TesteClienteAgenda.Application.ViewModels;
using TesteClienteAgenda.Domain.Models;

namespace TesteClienteAgenda.Application.Utils
{
    public class ExcelFiletoAgenda:IDisposable
    {
        private readonly Stream _fileStream;

        public ExcelFiletoAgenda(Stream fileStream)
        {
            _fileStream = fileStream;
        }

        private String RetornarConteudoArquivo()
        {
            String conteudoArquivo;
            using (StreamReader reader = new StreamReader(_fileStream))
            {
                conteudoArquivo = reader.ReadToEnd();
            }
            return conteudoArquivo;
        }

        public async Task<ICollection<AgendaViewModel>> ExcelToAgenda()
        {
            var conteudoArquivo = RetornarConteudoArquivo();

            ICollection<AgendaViewModel> agendas = new List<AgendaViewModel>();


            var stringCollection = await PrepararLeitura(conteudoArquivo.Split(';'));

            for (int i = 0; i < stringCollection.Count-1; i = i+3)
            {
                AgendaViewModel agenda = new AgendaViewModel
                {
                    NumeroTitulo = stringCollection[i],
                    ValorBruto = Convert.ToDecimal(stringCollection[i+1]),
                    DataLiquidacao = DateTime.ParseExact(stringCollection[i+2],"dd/MM/yyyy",null)
                };
                agendas.Add(agenda);
            }

            return agendas;
        }

        private async Task<IList<string>> PrepararLeitura(string[] leituraSuja)
        {
            IList<string> stringCollection = new List<string>();
            foreach (var parte in leituraSuja)
            {
                var quebra = parte.Split("\r\n");
                foreach (var parteQuebra in quebra)
                {
                    stringCollection.Add(parteQuebra);
                }
            }

            return stringCollection;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
