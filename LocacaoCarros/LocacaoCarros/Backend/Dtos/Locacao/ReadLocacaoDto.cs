namespace Backend.Dtos.Locacao
{
    public class ReadLocacaoDto
    {
        public int Id { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime DataEntrega { get; set; }
        public double ValorTotalLocacao { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
    }
}
