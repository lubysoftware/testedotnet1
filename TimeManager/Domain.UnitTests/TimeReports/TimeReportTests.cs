using System;
using TimeManager.Domain.Developers.TimeReports;
using Xunit;

namespace TimeManager.Domain.UnitTests.TimeReports
{
    public class TimeReportTests
    {
        private readonly DateTime _startedAt;
        private readonly DateTime _endedAt;
        private readonly int _thisWeekNumber;

        private readonly TimeReport _timeReport;

        public TimeReportTests()
        {
            _startedAt = DateTime.Now;
            _endedAt = DateTime.Now.AddHours(1);
            _thisWeekNumber = DateTime.Now.WeekNumberOfTheYear();
            _timeReport = new TimeReport(Guid.NewGuid(), Guid.NewGuid(), _startedAt, _endedAt);
        }

        [Fact]
        public void ShouldCalculateHoursWorked()
        {
            // Arrange

            var wokedTime = (_endedAt - _startedAt).TotalHours;

            // Assert
            Assert.Equal(wokedTime, _timeReport.CalculatedHoursWorked);
        }

        [Fact]
        public void ShouldCalculateCurrentWeekNumber()
        {
            Assert.Equal(_thisWeekNumber, _timeReport.CalculatedWeekOfTheYear);
        }
    }
}
