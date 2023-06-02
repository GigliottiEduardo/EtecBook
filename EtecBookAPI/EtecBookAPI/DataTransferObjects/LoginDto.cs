using System.ComponentModel.DataAnnotations;

namespace EtecBookAPI.DataTransferObject;

public class LoginDto
{
    [Required(ErrorMessage = "Informe o email ou nome de usuário")]
    [StringLength(100, ErrorMessage ="O email ou nome deve possuir no máximo 100 caracteres")]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Informe a senha")]
    [StringLength(20, ErrorMessage ="A senha deve possuir no máximo 20 caracteres")]
    public string Password { get; set; }
}