using System;

namespace test.domain.Entities
{
    public class Hours
    {
        public Guid Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        //public Developer Developer { get; set; }
        public string Developer { get; set; }
    }
}
