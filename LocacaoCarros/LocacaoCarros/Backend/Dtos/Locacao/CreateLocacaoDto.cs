namespace Backend.Dtos.Locacao
{
    public class CreateLocacaoDto
    {
        public DateTime DataColeta { get; set; }
        public DateTime DataEntrega { get; set; }
        public int IdVeiculo { get; set; }
        public int IdCliente { get; set; }
    }
}
