using System;
using Xunit;
using Xunit.Abstractions;

namespace PowerXtensions.DotNet.Tests
{
    public class DateTimeExtensionTests
    {
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        public DateTimeExtensionTests(ITestOutputHelper output)
        {
            _output = output;
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

        [Fact(DisplayName = "Test: Last Day Of Month")]
        public void LastDayOfMonthTests()
        {
            var date = new DateTime(2022, 1, 29, 0, 0, 0);
            var expectDate = new DateTime(2022, 1, 31, 0, 0, 0);
            var notExpectDate = new DateTime(2022, 1, 31, 0, 0, 1);

            //_output.WriteLine(date.LastDayOfMonth().ToString());

            Assert.Equal(expectDate, date.LastDayOfMonth());
            Assert.NotEqual(notExpectDate, date.LastDayOfMonth());
        }

        [Fact(DisplayName = "Test: First Time Of Day")]
        public void FirstTimeOfDayTests()
        {
            var date = new DateTime(2022, 1, 29, 15, 15, 15);
            var expectDate = new DateTime(2022, 1, 29, 0, 0, 0);
            var notExpectDate = new DateTime(2022, 1, 29, 23, 59, 59);

            //_output.WriteLine(date.LastDayOfMonth().ToString());

            Assert.Equal(expectDate, date.FirstTimeOfDay());
            Assert.NotEqual(notExpectDate, date.FirstTimeOfDay());
        }

        [Fact(DisplayName = "Test: Last Time Of Day")]
        public void LastTimeOfDayTests()
        {
            var date = new DateTime(2022, 1, 29, 15, 15, 15);
            var expectDate = new DateTime(2022, 1, 29, 23, 59, 59);
            var notExpectDate = new DateTime(2022, 1, 29, 0, 0, 0);

            //_output.WriteLine(date.LastDayOfMonth().ToString());

            Assert.Equal(expectDate, date.LastTimeOfDay());
            Assert.NotEqual(notExpectDate, date.LastTimeOfDay());
        }

        [Fact(DisplayName = "Test: Next Business Day")]
        public void NextBusinessDayTests()
        {
            var date = new DateTime(2022, 1, 29, 15, 15, 15);
            var expectDate = new DateTime(2022, 1, 31, 15, 15, 15);
            var notExpectDate = new DateTime(2022, 1, 30, 15, 15, 15);

            //_output.WriteLine(date.LastDayOfMonth().ToString());

            Assert.Equal(expectDate, date.NextBusinessDay());
            Assert.NotEqual(notExpectDate, date.NextBusinessDay());

            var date2 = new DateTime(2022, 1, 29, 15, 15, 15);
            var expectDate2 = new DateTime(2022, 2, 1, 15, 15, 15);
            var notExpectDate2 = new DateTime(2022, 1, 31, 15, 15, 15);

            Assert.Equal(expectDate2, date2.NextBusinessDay(new DateTime(2022, 1, 31)));
            Assert.NotEqual(notExpectDate2, date2.NextBusinessDay(new DateTime(2022, 1, 31)));
        }

        // [Fact(DisplayName = "Test: First Business Day Of Current Week")]
        // public void FirstBusinessDayOfCurrentWeekTests()
        // {
        //     var date = new DateTime(2022, 1, 29, 15, 15, 15);
        //     var expectDate = new DateTime(2022, 1, 24, 15, 15, 15);
        //     var notExpectDate = new DateTime(2022, 1, 31, 15, 15, 15);

        //     //_output.WriteLine(date.LastDayOfMonth().ToString());

        //     Assert.Equal(expectDate, date.FirstBusinessDayOfCurrentWeek());
        //     Assert.NotEqual(notExpectDate, date.FirstBusinessDayOfCurrentWeek());

        //     var date2 = new DateTime(2022, 1, 29, 15, 15, 15);
        //     var expectDate2 = new DateTime(2022, 1, 25, 15, 15, 15);
        //     var notExpectDate2 = new DateTime(2022, 1, 24, 15, 15, 15);

        //     Assert.Equal(expectDate2, date2.NextBusinessDay(new DateTime(2022, 1, 24)));
        //     Assert.NotEqual(notExpectDate2, date2.NextBusinessDay(new DateTime(2022, 1, 24)));
        // }
    }
}