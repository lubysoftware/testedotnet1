using System;

namespace Hours.Domain.Entities
{
    public class HoursEntity : BaseEntity
    {      
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Developer { get; set; }
    }
}
