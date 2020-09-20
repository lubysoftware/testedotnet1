using System;
using System.Globalization;

namespace TimeManager.Domain
{
    public static class DateTimeExtensions
    {
        public static int WeekNumberOfTheYear(this DateTime _)
        {
            CultureInfo myCI = new CultureInfo("pt-BR");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            DateTime today = DateTime.Now;

            return myCal.GetWeekOfYear(today, myCWR, myFirstDOW);
        }

        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Sunday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
    }
}
