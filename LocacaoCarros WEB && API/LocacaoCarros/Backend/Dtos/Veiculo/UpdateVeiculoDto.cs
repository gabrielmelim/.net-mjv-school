using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Veiculo;

public class UpdateVeiculoDto
{
    [MinLength(3, ErrorMessage = "O tipo deve conter ao menos 3 caracteres!")]
    [MaxLength(100, ErrorMessage = "O tipo não deve exceder 100 caracteres!")]
    [Required(ErrorMessage = "Tipo deve ser informado!")]
    public  String TipoVeiculo { get; set; }
    
    [MinLength(3, ErrorMessage = "A marca deve conter ao menos 3 caracteres!")]
    [MaxLength(200, ErrorMessage = "A marca não deve exceder 200 caracteres!")]
    [Required(ErrorMessage = "Marca deve ser informado!")]
    public string Marca { get; set; }
    
    [MinLength(3, ErrorMessage = "O modelo deve conter ao menos 3 caracteres!")]
    [MaxLength(200, ErrorMessage = "O modelo não deve exceder 200 caracteres!")]
    [Required(ErrorMessage = "Modelo deve ser informado!")]
    public string Modelo { get; set; }
    
    [MinLength(3, ErrorMessage = "A placa deve conter ao menos 3 caracteres!")]
    [MaxLength(50, ErrorMessage = "A placa não deve exceder 50 caracteres!")]
    [Required(ErrorMessage = "Placa deve ser informado!")]
    public string Placa { get; set; }
    
    [Range(0, 999999.99, ErrorMessage = "O valor da diária deve estar entre 0 e 999999.99.")]
    public double ValorDiaria { get; set; }
}