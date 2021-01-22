
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiRestDevs.Models
{
    public class User
    {
        public User()
        {
        }

        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        [MaxLength(60, ErrorMessage = "Tamanho do nome deve ser entre 3 e 60 carecteres")]
        [MinLength(3, ErrorMessage = "Tamanho do nome deve ser entre 3 e 60 carecteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este Campo é Obrigatório")]
        public string Password { get; set; }

        [JsonIgnore]
        public string Role { get; set; }
    }
}
