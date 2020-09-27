using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace testedotnet1.Entities
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}