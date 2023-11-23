using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Nome { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        public virtual ICollection<Locacao> Locacoes { get; set; }
    }
}
