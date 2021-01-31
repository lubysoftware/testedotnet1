using System.ComponentModel.DataAnnotations;

namespace LubyWebMvc.Models.Developers
{
    public class RegisterDeveloperViewModelInput
    {
        [Required(ErrorMessage = "O Login é Obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Email é Obrigatório")]
        [EmailAddress(ErrorMessage = "Entre um Email Válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é Obrigatória")]
        public string Password { get; set; }
    }
}
