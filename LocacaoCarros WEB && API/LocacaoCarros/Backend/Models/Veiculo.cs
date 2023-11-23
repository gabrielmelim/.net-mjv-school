using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string TipoVeiculo { get; set; }
        [StringLength(200)]
        public string Marca { get; set; }
        [StringLength(200)]
        public string Modelo { get; set; }
        [StringLength(50)]
        public string Placa { get; set; }
        
        [Range(0, 999999.99)] // Altere os valores conforme necessário
        public double ValorDiaria { get; set; }
        public virtual ICollection<Locacao> Locacoes { get; set; }
    }
}
