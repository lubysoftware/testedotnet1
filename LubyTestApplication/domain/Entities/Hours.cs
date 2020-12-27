using System;

namespace test.domain.Entities
{
    public class Hours
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Developer Developer { get; set; }
    }
}
