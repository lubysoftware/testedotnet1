using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace testedotnet1.Entities
{
    public class HoursAtWork
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }

        [Required]
        public long Hours { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public int IdProject { get; set; }

        [Required]
        public Project Project { get; set; }
    }
}