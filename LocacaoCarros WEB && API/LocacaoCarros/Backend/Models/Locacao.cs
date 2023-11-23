using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Locacao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime DataEntrega { get; set; }
        public double ValorTotalLocacao { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
    }
}
