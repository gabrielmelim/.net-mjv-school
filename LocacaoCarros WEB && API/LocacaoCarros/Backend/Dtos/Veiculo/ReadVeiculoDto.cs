namespace Backend.Dtos.Veiculo
{
    public class ReadVeiculoDto
    {
        public int Id { get; set; }
        public string TipoVeiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public double ValorDiaria { get; set; }
    }
}
