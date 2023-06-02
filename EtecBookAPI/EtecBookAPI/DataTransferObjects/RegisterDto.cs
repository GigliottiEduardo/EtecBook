using System.ComponentModel.DataAnnotations;


namespace EtecBookAPI.DataTransferObject;

public class RegisterDto
{

    [Required(ErrorMessage ="Informe seu nome")]
    [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o email ")]
    [EmailAddress(ErrorMessage = "Informe um Email Válido!")]
    [StringLength(100, ErrorMessage = "O email deve possuir no máximo 100 caracteres")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Informe a senha")]
    [StringLength(20, MinimumLength = 6, 
        ErrorMessage = "A senha deve possuir no minimo 6 e no máximo 20 caracteres")]
    public string Password { get; set; }
}