using System;
using System.Globalization;

namespace TimeManager.Domain
{
    public static class DateTimeExtensions
    {
        public static int WeekNumberOfTheYear(this DateTime dateTime)
        {
            CultureInfo myCI = new CultureInfo("pt-BR");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            DateTime today = DateTime.Now;

            return myCal.GetWeekOfYear(today, myCWR, myFirstDOW);
        }
    }
}
