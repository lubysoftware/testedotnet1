using System;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class LaunchTimeViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Initial { get; set; }
        public DateTime? End { get; set; }
        public Guid? IdProject { get; set; }
        public Guid? IdDeveloper { get; set; }
        public ProjectViewModel Project { get; set; }
        public DeveloperViewModel Developer { get; set; }
        public double ProxyHoras { get; set; }


    }
}
