using Hours.Application.DataContract.Response.Base;

namespace Hours.Application.DataContract.Response.Hours
{
    public class HoursRankingResponse : BaseReponse
    {
        public string Developer { get; set; }
        public string TotalOfHoursWorked { get; set; }
        public string AverageHoursWorked { get; set; }
    }
}
