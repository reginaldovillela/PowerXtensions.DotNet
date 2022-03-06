using System;

namespace PowerXtensions.DotNet
{
    /// <summary>
    /// Class with DateTime Extensions
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Checks if the date entered is a weekend day
        /// </summary>
        /// <param name="value">Reference DateTime</param>
        /// <returns>Returns true if it's a weekend</returns>
        public static bool IsWeekend(this DateTime value)
        {
            return IsDayWeekend(value);
        }

        /// <summary>
        /// Returns a DateTime of the first day of the month
        /// </summary>
        /// <param name="value">Reference DateTime</param>
        /// <returns>Returns a DateTime</returns>
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return value.AddDays(-(value.Day - 1));
        }

        /// <summary>
        /// Returns a DateTime of the last day of the month
        /// </summary>
        /// <param name="value">Reference DateTime</param>
        /// <returns>Returns a DateTime</returns>
        public static DateTime LastDayOfMonth(this DateTime value)
        {
            var date = value;

            while (date.Month == value.Month)
                date = date.AddDays(1);

            return date.AddDays(-1);
        }

        /// <summary>
        /// Returns a DateTime of the first time of the day
        /// </summary>
        /// <param name="value">Reference DateTime</param>
        /// <returns>Returns a DateTime</returns>
        public static DateTime FirstTimeOfDay(this DateTime value)
        {
            return value.Date;
        }

        /// <summary>
        /// Returns a DateTime of the last time of the day
        /// </summary>
        /// <param name="value">Reference DateTime</param>
        /// <returns>Returns a DateTime</returns>
        public static DateTime LastTimeOfDay(this DateTime value)
        {
            return value.Date.AddDays(1).AddSeconds(-1);
        }

        /// <summary>
        /// Returns a DateTime for the next business day
        /// </summary>
        /// <param name="value">Reference DateTime</param>
        /// <param name="daysOff">Holiday list</param>
        /// <returns>Returns a DateTime</returns>
        public static DateTime NextBusinessDay(this DateTime value, params DateTime[] daysOff)
        {
            do
            {
                value = value.AddDays(1);
            }
            while (IsDayWeekend(value) || IsDayOff(value, daysOff));

            return value;
        }

        // /// <summary>
        // /// Returns a DateTime the first working day of the current week
        // /// </summary>
        // /// <param name="value">Reference DateTime</param>
        // /// <param name="daysOff">Holiday list</param>
        // /// <returns>Returns a DateTime</returns>
        // public static DateTime FirstBusinessDayOfCurrentWeek(this DateTime value, params DateTime[] daysOff)
        // {
        //     if (IsDayOff(value, daysOff))
        //         FirstBusinessDayOfCurrentWeek(value.AddDays(1), daysOff);

        //     if (value.DayOfWeek == DayOfWeek.Sunday)
        //         FirstBusinessDayOfCurrentWeek(value.AddDays(1), daysOff);


        //     if (IsDayWeekend(value) || IsDayOff(value, daysOff))
        //         if (value.DayOfWeek == DayOfWeek.Saturday)
        //             FirstBusinessDayOfCurrentWeek(value.AddDays(-1), daysOff);

        //     return value;
        // }

        #region Private

        private static bool IsDayWeekend(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday ||
                   dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        private static bool IsDayOff(DateTime dateTime, params DateTime[] daysOff)
        {
            for (var i = 0; i < daysOff.Length; i++)
                if (dateTime.Date == daysOff[i].Date)
                    return true;

            return false;
        }

        #endregion

    }
}