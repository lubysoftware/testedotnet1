using System;
using Xunit;

namespace TimeManager.Domain.UnitTests.SharedKernelTests
{
    public class DateTimeExtensionsTests
    {
        private readonly int _thisWeekNumber;
        public DateTimeExtensionsTests()
        {
            _thisWeekNumber = DateTime.Now.WeekNumberOfTheYear();
        }

        [Fact]
        public void ShouldRespectTheDateInformed()
        {
            // Arrange
            var nextWeek = DateTime.Now.AddDays(7).WeekNumberOfTheYear();
            var previousWeek = DateTime.Now.AddDays(-7).WeekNumberOfTheYear();

            // Assert
            Assert.NotEqual(_thisWeekNumber, nextWeek);
            Assert.Equal(_thisWeekNumber + 1, nextWeek);
            Assert.Equal(_thisWeekNumber - 1, previousWeek);
        }
    }
}
