using System;
using Xunit;

namespace PowerXtensions.DotNet.Tests;

public class DateTimeExtensionTests
{
    [Fact(DisplayName = "Test: Difference In Days Between Dates")]
    public void DifferenceInDaysBetweenDatesTests()
    {
        var initialDate = new DateTime(2022, 1, 1);
        var endDate = new DateTime(2022, 1, 20);

        Assert.Equal(19, initialDate.DifferenceInDaysBetweenDates(endDate));
        Assert.NotEqual(20, initialDate.DifferenceInDaysBetweenDates(endDate));

        Assert.Equal(14, initialDate.DifferenceInDaysBetweenDates(endDate, true));
        Assert.NotEqual(19, initialDate.DifferenceInDaysBetweenDates(endDate, true));
        
        Assert.Equal(0, initialDate.DifferenceInDaysBetweenDates(initialDate));
        Assert.NotEqual(20, initialDate.DifferenceInDaysBetweenDates(initialDate));
    }

    [Fact(DisplayName = "Test: Date Is Weekend")]
    public void IsWeekendTests()
    {
        var weekDate = new DateTime(2022, 1, 3);
        var weekendDate = new DateTime(2022, 1, 2);

        Assert.False(weekDate.IsWeekend());
        Assert.True(weekendDate.IsWeekend());
    }

    [Fact(DisplayName = "Test: First Day Of Month")]
    public void FirstDayOfMonthTests()
    {
        var date = new DateTime(2022, 1, 18, 0, 0, 0);
        var expectDate = new DateTime(2022, 1, 1, 0, 0, 0);
        var notExpectDate = new DateTime(2022, 1, 1, 0, 0, 1);

        Assert.Equal(expectDate, date.FirstDayOfMonth());
        Assert.NotEqual(notExpectDate, date.FirstDayOfMonth());
    }

    [Fact(DisplayName = "Test: First Time Of Day")]
    public void FirstTimeOfDayTests()
    {
        var date = new DateTime(2022, 1, 29, 15, 15, 15);
        var expectDate = new DateTime(2022, 1, 29, 0, 0, 0);
        var notExpectDate = new DateTime(2022, 1, 29, 23, 59, 59);

        Assert.Equal(expectDate, date.FirstTimeOfDay());
        Assert.NotEqual(notExpectDate, date.FirstTimeOfDay());
    }

    [Fact(DisplayName = "Test: Last Day Of Month")]
    public void LastDayOfMonthTests()
    {
        var date = new DateTime(2022, 1, 29, 0, 0, 0);
        var expectDate = new DateTime(2022, 1, 31, 0, 0, 0);
        var notExpectDate = new DateTime(2022, 1, 31, 0, 0, 1);

        Assert.Equal(expectDate, date.LastDayOfMonth());
        Assert.NotEqual(notExpectDate, date.LastDayOfMonth());
    }

    [Fact(DisplayName = "Test: Last Time Of Day")]
    public void LastTimeOfDayTests()
    {
        var date = new DateTime(2022, 1, 29, 15, 15, 15);
        var expectDate = new DateTime(2022, 1, 29, 23, 59, 59);
        var notExpectDate = new DateTime(2022, 1, 29, 0, 0, 0);

        Assert.Equal(expectDate, date.LastTimeOfDay());
        Assert.NotEqual(notExpectDate, date.LastTimeOfDay());
    }

    [Fact(DisplayName = "Test: Next Business Day")]
    public void NextBusinessDayTests()
    {
        var date = new DateTime(2022, 1, 29, 15, 15, 15);
        var expectDate = new DateTime(2022, 1, 31, 15, 15, 15);
        var notExpectDate = new DateTime(2022, 1, 30, 15, 15, 15);

        Assert.Equal(expectDate, date.NextBusinessDay());
        Assert.NotEqual(notExpectDate, date.NextBusinessDay());

        var date2 = new DateTime(2022, 1, 29, 15, 15, 15);
        var expectDate2 = new DateTime(2022, 2, 1, 15, 15, 15);
        var notExpectDate2 = new DateTime(2022, 1, 31, 15, 15, 15);

        var daysOff = new DateTime[]
        {
            new DateTime(2022, 1, 31)
        };

        Assert.Equal(expectDate2, date2.NextBusinessDay(new DateTime(2022, 1, 31)));
        Assert.NotEqual(notExpectDate2, date2.NextBusinessDay(new DateTime(2022, 1, 31)));
    }

    [Fact(DisplayName = "Test: Years Old")]
    public void YearsOldTests()
    {
        var dateBirth = new DateTime(1955, 10, 28);

        Assert.Equal(66, dateBirth.YearsOld());
        Assert.NotEqual(65, dateBirth.YearsOld());
    }
}