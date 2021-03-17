using System;

namespace LTS.Domain.Entities
{
    public class DeveloperProject
    {
        public Guid DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}