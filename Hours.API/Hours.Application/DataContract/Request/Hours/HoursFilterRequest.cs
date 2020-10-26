using System;

namespace Hours.Application.DataContract.Request.Hours
{
    public sealed class HoursFilterRequest
    {
        public Guid? Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Developer { get; set; }
    }
}
