using System;

namespace Lubby.Domain.Root
{
    public class Work
    {
        public string WorkId { get; set; }
        public Project Project { get; set; }
        public Developer Dev { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
