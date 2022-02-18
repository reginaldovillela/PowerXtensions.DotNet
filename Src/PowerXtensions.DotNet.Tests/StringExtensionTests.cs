using System;
using Xunit;

namespace PowerXtensions.DotNet.Tests
{
    public class StringExtensionTests
    {
        private const string TEXT_TO_TEST = "PowerXtensions StringXtension @ 9876543210";

        public static readonly object[][] DataToDateTimeTest =
        {
            new object[] { "12/10/2000", "dd/MM/yyyy", new DateTime(2000, 10, 12)},
        };

        [Theory(DisplayName = "Test: Convert To DateTime")]
        [MemberData(nameof(DataToDateTimeTest))]
        public void ToDateTimeTest(string dateTimeText, string format, DateTime expectValue)
        {
            Assert.Equal(expectValue, dateTimeText.ToDateTime(format));
        }

        [Fact(DisplayName = "Test: Contains")]
        public void ContainsTest()
        {
            Assert.True(TEXT_TO_TEST.Contains("Power", "Xtensions"));
            Assert.False(TEXT_TO_TEST.Contains("power", "xtensions"));
        }

        [Fact(DisplayName = "Test: Has More Than One Word")]
        public void HasMoreThanOneWord()
        {
            Assert.True("Power Xtensions".HasMoreThanOneWord());
            Assert.False("PowerXtensions".HasMoreThanOneWord());
        }

        [Fact(DisplayName = "Test: Only Numbers")]
        public void OnlyNumbersTest()
        {
            Assert.Equal("9876543210", TEXT_TO_TEST.OnlyNumbers());
        }
    }
}