using System;

namespace Hours.Application.DataContract.Request.Hours
{
    public sealed class HoursGeneralRequest
    {
        public DateTime StartDate { get; set; }   
        public DateTime EndDate { get; set; }
        public string Developer { get; set; }
    }
}
