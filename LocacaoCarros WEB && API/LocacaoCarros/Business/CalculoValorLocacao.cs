using Business.Contracts;

namespace Business
{
    public class CalculoValorLocacao : ICalculoValorLocacao
    {
        public double CalcularValorLocacao(DateTime dataColeta, DateTime dataEntrega, double valorDiaria)
        {
            var diasLocacao = dataEntrega.Subtract(dataColeta).TotalDays;

            return diasLocacao * valorDiaria;
        }
    }
}
