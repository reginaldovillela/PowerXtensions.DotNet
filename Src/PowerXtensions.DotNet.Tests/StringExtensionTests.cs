using System;
using Xunit;

namespace PowerXtensions.DotNet.Tests
{
    public class StringExtensionTests
    {
        private const string PLAIN_TEXT_TO_TEST = "PowerXtensions StringXtension @ 9876543210";
        private const string BASE64_TEXT_TO_TEST = "UG93ZXJYdGVuc2lvbnMgU3RyaW5nWHRlbnNpb24gQCA5ODc2NTQzMjEw";
        private const string HEXA_TEXT_TO_TEST = "506f7765725874656e73696f6e7320537472696e675874656e73696f6e20402039383736353433323130";

        public static readonly object[][] DataToDateTimeTest =
        {
            new object[] { "12/10/2000", "dd/MM/yyyy", new DateTime(2000, 10, 12)},
        };

        public static readonly object[][] DataToNullableDateTimeTest =
        {
            new object[] { "12/10/2000", "dd/MM/yyyy", (DateTime?)(new DateTime(2000, 10, 12)) },
        };

        [Fact(DisplayName = "Test: All Characters Are The Same")]
        public void AllCharactersSameTest()
        {
            Assert.True("1111111111".AllCharactersSame());
            Assert.False("1234567890".AllCharactersSame());
        }

        [Fact(DisplayName = "Test: Convert Text To Base64")]
        public void Base64EncodeTest()
        {
            Assert.Equal(BASE64_TEXT_TO_TEST, PLAIN_TEXT_TO_TEST.Base64Encode());
        }

        [Fact(DisplayName = "Test: Convert Base64 To Text")]
        public void Base64DecodeTest()
        {
            Assert.Equal(PLAIN_TEXT_TO_TEST, BASE64_TEXT_TO_TEST.Base64Decode());
        }

        [Fact(DisplayName = "Test: Convert Text To Hexadecimal")]
        public void HexadecimalEncodeTest()
        {
            Assert.Equal(HEXA_TEXT_TO_TEST, PLAIN_TEXT_TO_TEST.HexadecimalEncode());
        }

        [Fact(DisplayName = "Test: Convert Hexadecimal To Text")]
        public void HexadecimalDecodeTest()
        {
            Assert.Equal(PLAIN_TEXT_TO_TEST, HEXA_TEXT_TO_TEST.HexadecimalDecode());
        }

        [Theory(DisplayName = "Test: Convert To DateTime")]
        [MemberData(nameof(DataToDateTimeTest))]
        public void ToDateTimeTest(string dateTimeText, string format, DateTime expectValue)
        {
            Assert.Equal(expectValue, dateTimeText.ToDateTime(format));
        }

        [Theory(DisplayName = "Test: Convert To Nullable DateTime")]
        [MemberData(nameof(DataToNullableDateTimeTest))]
        public void ToNullDateTimeTest(string dateTimeText, string format, DateTime? expectValue)
        {
            Assert.IsType(expectValue?.GetType(), dateTimeText.ToNullableDateTime(format));
            Assert.Equal(expectValue, dateTimeText.ToNullableDateTime(format));
        }

        [Fact(DisplayName = "Test: Convert To Integer")]
        public void ToIntTest()
        {
            var number = "12345";

            Assert.Equal(12345, number.ToInt());
        }

        [Fact(DisplayName = "Test: Convert To Nullable Integer")]
        public void ToNullableIntTest()
        {
            var number = "12345";
            var notNumber = "12345A";

            Assert.Equal(12345, number.ToNullableInt());
            Assert.Null(notNumber.ToNullableInt());
        }

        [Fact(DisplayName = "Test: Convert To Long")]
        public void ToLongTest()
        {
            var number = "1234567890";

            Assert.Equal(1234567890, number.ToLong());
        }

        [Fact(DisplayName = "Test: Convert To Nullable Long")]
        public void ToNullableLongTest()
        {
            var number = "1234567890";
            var notNumber = "1234567890A";

            Assert.Equal(1234567890, number.ToNullableLong());
            Assert.Null(notNumber.ToNullableLong());
        }

        [Fact(DisplayName = "Test: Convert To Short")]
        public void ToShortTest()
        {
            var number = "123";

            Assert.Equal(123, number.ToLong());
        }

        [Fact(DisplayName = "Test: Convert To Nullable Short")]
        public void ToNullableShortTest()
        {
            var number = "123";
            var notNumber = "123A";

            Assert.Equal(123, number.ToNullableLong());
            Assert.Null(notNumber.ToNullableLong());
        }

        [Fact(DisplayName = "Test: Contains")]
        public void ContainsTest()
        {
            Assert.True(PLAIN_TEXT_TO_TEST.Contains("Power", "Xtensions"));
            Assert.False(PLAIN_TEXT_TO_TEST.Contains("power", "xtensions"));
        }

        [Fact(DisplayName = "Test: Is Null, Empty Or White Space")]
        public void IsNullOrEmptyOrWhiteSpaceTest()
        {
            var test = (string?)null;

            Assert.True(test.IsNullOrEmptyOrWhiteSpace());
            Assert.True("".IsNullOrEmptyOrWhiteSpace());
            Assert.True(" ".IsNullOrEmptyOrWhiteSpace());
            Assert.False("123 ".IsNullOrEmptyOrWhiteSpace());
        }

        [Fact(DisplayName = "Test: Has More Than One Word")]
        public void HasMoreThanOneWordTest()
        {
            Assert.True(PLAIN_TEXT_TO_TEST.HasMoreThanOneWord());
            Assert.False("PowerXtensions".HasMoreThanOneWord());
        }

        [Fact(DisplayName = "Test: Only Numbers")]
        public void OnlyNumbersTest()
        {
            Assert.Equal("9876543210", PLAIN_TEXT_TO_TEST.OnlyNumbers());
            Assert.NotEqual("abc_9876543210", PLAIN_TEXT_TO_TEST.OnlyNumbers());
        }

        [Fact(DisplayName = "Test: Remove")]
        public void RemoveTest()
        {
            Assert.Equal("PowerXtensions StringXtension", PLAIN_TEXT_TO_TEST.Remove(" @ 9876543210"));
        }
    }
}