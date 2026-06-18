using System;

namespace Hours.Application.DataContract.Response.Hours
{
    public class HoursGeneralResponse
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Developer { get; set; }
    }
}
