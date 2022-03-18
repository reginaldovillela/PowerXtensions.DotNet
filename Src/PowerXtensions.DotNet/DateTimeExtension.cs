using System;

namespace PowerXtensions.DotNet;

/// <summary>
/// Class with DateTime Extensions
/// </summary>
public static class DateTimeExtension
{
    /// <summary>
    /// Calculates the difference in days between dates
    /// </summary>
    /// <param name="value">Reference DateTime</param>
    /// <param name="dateTimeToCompare">DateTime To Compare</param>
    /// <param name="ignoreWeekend">If true, ignore weekends in count. Default: false</param>
    /// <returns>Returns the difference in days</returns>
    public static int DifferenceInDaysBetweenDates(this DateTime value, DateTime dateTimeToCompare,
        bool ignoreWeekend = false)
    {
        var days = dateTimeToCompare.Subtract(value).Days;

        if (ignoreWeekend)
            for (var i = 0; i < days; i++)
                if (IsDayWeekend(value.AddDays(i)))
                    days--;

        return days > 0 ? days : 0;
    }

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
    /// Returns a DateTime of the first time of the day
    /// </summary>
    /// <param name="value">Reference DateTime</param>
    /// <returns>Returns a DateTime</returns>
    public static DateTime FirstTimeOfDay(this DateTime value)
    {
        return value.Date;
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
        } while (IsDayWeekend(value) || IsDayOff(value, daysOff));

        return value;
    }

    /// <summary>
    /// Calculate Age
    /// </summary>
    /// <param name="value">Birth Date</param>
    /// <returns>Return age in years</returns>
    public static int YearsOld(this DateTime value)
    {
        var now = DateTime.Now;
        var years = now.Year - value.Year;

        if (now.DayOfYear < value.DayOfYear)
            years--;

        return years;
    }

    #region Private

    private static bool IsDayWeekend(DateTime dateTime)
    {
        return dateTime.DayOfWeek is
            DayOfWeek.Saturday or
            DayOfWeek.Sunday;
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