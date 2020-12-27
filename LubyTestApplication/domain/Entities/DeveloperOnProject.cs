using System;

namespace test.domain.Entities
{
    public class DeveloperOnProject
    {
        public Guid Id { get; set; }
        public Guid DeveloperId { get; set; }
        public Guid ProjectId { get; set; }
        public Developer Developer { get; set; }
        public Project Project { get; set; }
    }
}
