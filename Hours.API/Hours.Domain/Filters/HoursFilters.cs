using System;

namespace Hours.Domain.Filters
{
    public sealed class HoursFilters
    {
        public string Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Developer { get; set; }
    }
}