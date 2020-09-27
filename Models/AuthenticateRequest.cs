using System.ComponentModel.DataAnnotations;

namespace testedotnet1.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password
        {
            get; set;
        }
    }
}