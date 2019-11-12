using System;

namespace TesteClienteAgenda.Infra.CrossCutting.Helpers.Helpers
{
    public class CalculoDataHelper:IDisposable
    {
        private readonly DateTime _dataInicial;
        private readonly DateTime _dataFinal;

        public CalculoDataHelper(DateTime dataInicial, DateTime dataFinal)
        {
            _dataInicial = dataInicial;
            _dataFinal = dataFinal;
        }

        public int CalcularDiferencaEmAnos()
        {
            TimeSpan date = _dataFinal - _dataInicial;
            return date.Days / 365;
        }

        public bool DiferencaMaiorQueUmAno()
        {
            return CalcularDiferencaEmAnos() >= 1;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}