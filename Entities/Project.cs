using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace testedotnet1.Entities
{
    public class Project
    {
        [JsonIgnore]
        public int IdProject { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public long HoursProject { get; set; }
        public ICollection<HoursAtWork> HoursWork { get; set; }
    }
}