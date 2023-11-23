namespace Frontend.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime DataEntrega { get; set; }
        public double ValorTotalLocacao { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
    }
}
