using System.ComponentModel.DataAnnotations;

namespace Hours.Domain.DTO
{
    public class LoginDTO
    {        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
