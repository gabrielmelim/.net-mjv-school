namespace Business.Contracts
{
    public interface ICalculoValorLocacao
    {
        double CalcularValorLocacao(DateTime dataColeta, DateTime dataEntrega, double valorDiaria);
    }
}
