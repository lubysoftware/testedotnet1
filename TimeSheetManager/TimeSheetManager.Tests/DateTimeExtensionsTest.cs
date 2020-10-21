using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimeSheetManager.Domain.Extensions;

namespace TimeSheetManager.Tests
{
    [TestClass]
    public class DateTimeExtensionsTest
    {
        private readonly int _WeekID;
        public DateTimeExtensionsTest()
        {
            _WeekID = DateTime.Now.WeekNumberOfTheYear();
        }
        [TestMethod]
        public void TestGetWeekIdDateExtension()
        {
            var nextWeek = DateTime.Now.AddDays(7).WeekNumberOfTheYear();
            var previousWeek = DateTime.Now.AddDays(-7).WeekNumberOfTheYear();

            Assert.AreEqual(_WeekID + 1, nextWeek);
            Assert.AreEqual(_WeekID - 1, previousWeek);
            Assert.AreNotEqual(_WeekID, nextWeek);
        }
    }
}