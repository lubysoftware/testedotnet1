using System;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class ProjectViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? Concluded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
