using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Cliente
{
    public class UpdateClienteDto
    {
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres!")]
        [MaxLength(200, ErrorMessage = "O nome não deve exceder 50 caracteres!")]
        [Required(ErrorMessage = "Nome deve ser informado!")]
        public string Nome { get; set; }
        [MinLength(3, ErrorMessage = "O e-mail deve conter ao menos 3 caracteres!")]
        [MaxLength(200, ErrorMessage = "O e-mail não deve exceder 50 caracteres!")]
        [Required(ErrorMessage = "E-mail deve ser informado!")]
        public string Email { get; set; }
    }
}
