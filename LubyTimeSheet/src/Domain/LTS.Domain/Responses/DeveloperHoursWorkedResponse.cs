using System;

namespace LTS.Domain.Responses
{
    public class DeveloperHoursWorkedResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TotalHourPerWeek { get; set; }
    }
}
