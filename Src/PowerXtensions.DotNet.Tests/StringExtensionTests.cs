using System;
using System.Text;
using Xunit;

namespace PowerXtensions.DotNet.Tests;

public class StringExtensionTests
{
    private const string PlainTextToTest = "PowerXtensions StringXtension @ 9876543210";
    private const string Base64TextToTest = "UG93ZXJYdGVuc2lvbnMgU3RyaW5nWHRlbnNpb24gQCA5ODc2NTQzMjEw";

    private const string HexaTextToTest =
        "506f7765725874656e73696f6e7320537472696e675874656e73696f6e20402039383736353433323130";

    public static readonly object[][] DataToDateTimeTest =
    {
        new object[] {"12/10/2000", "dd/MM/yyyy", new DateTime(2000, 10, 12)},
    };

    public static readonly object[][] DataToNullableDateTimeTest =
    {
        new object[] {"12/10/2000", "dd/MM/yyyy", (DateTime?) (new DateTime(2000, 10, 12))},
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
        Assert.Equal(Base64TextToTest, PlainTextToTest.Base64Encode());
    }

    [Fact(DisplayName = "Test: Convert Base64 To Text")]
    public void Base64DecodeToStringTest()
    {
        Assert.Equal(PlainTextToTest, Base64TextToTest.Base64Decode());
        Assert.Equal(PlainTextToTest, Base64TextToTest.Base64DecodeToString());
    }
    
    [Fact(DisplayName = "Test: Convert Base64 To Bytes")]
    public void Base64DecodeToBytesTest()
    {
        var bytes = Encoding.UTF8.GetBytes(PlainTextToTest);
        
        Assert.Equal(bytes, Base64TextToTest.Base64DecodeToBytes());
        Assert.NotEqual(Array.Empty<byte>(), Base64TextToTest.Base64DecodeToBytes());
    }

    [Fact(DisplayName = "Test: Convert Text To Hexadecimal")]
    public void HexadecimalEncodeTest()
    {
        Assert.Equal(HexaTextToTest, PlainTextToTest.HexadecimalEncode());
    }

    [Fact(DisplayName = "Test: Convert Hexadecimal To Text")]
    public void HexadecimalDecodeTest()
    {
        Assert.Equal(PlainTextToTest, HexaTextToTest.HexadecimalDecode());
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
        const string number = "12345";

        Assert.Equal(12345, number.ToInt());
    }

    [Fact(DisplayName = "Test: Convert To Nullable Integer")]
    public void ToNullableIntTest()
    {
        const string number = "12345";
        const string notNumber = "12345A";

        Assert.Equal(12345, number.ToNullableInt());
        Assert.Null(notNumber.ToNullableInt());
    }

    [Fact(DisplayName = "Test: Convert To Long")]
    public void ToLongTest()
    {
        const string number = "1234567890";

        Assert.Equal(1234567890, number.ToLong());
    }

    [Fact(DisplayName = "Test: Convert To Nullable Long")]
    public void ToNullableLongTest()
    {
        const string number = "1234567890";
        const string notNumber = "1234567890A";

        Assert.Equal(1234567890, number.ToNullableLong());
        Assert.Null(notNumber.ToNullableLong());
    }

    [Fact(DisplayName = "Test: Convert To Short")]
    public void ToShortTest()
    {
        const string number = "123";

        Assert.Equal(123, number.ToLong());
    }

    [Fact(DisplayName = "Test: Convert To Nullable Short")]
    public void ToNullableShortTest()
    {
        const string number = "123";
        const string notNumber = "123A";

        Assert.Equal(123, number.ToNullableLong());
        Assert.Null(notNumber.ToNullableLong());
    }

    [Fact(DisplayName = "Test: Contains")]
    public void ContainsTest()
    {
        Assert.True(PlainTextToTest.Contains("Power", "Xtensions"));
        Assert.False(PlainTextToTest.Contains("power", "xtensions"));
    }

    [Fact(DisplayName = "Test: Is Null, Empty Or White Space")]
    public void IsNullOrEmptyOrWhiteSpaceTest()
    {
        const string? test = (string?) null;

        Assert.True(test.IsNullOrEmptyOrWhiteSpace());
        Assert.True("".IsNullOrEmptyOrWhiteSpace());
        Assert.True(" ".IsNullOrEmptyOrWhiteSpace());
        Assert.False("123 ".IsNullOrEmptyOrWhiteSpace());
    }

    [Fact(DisplayName = "Test: Has More Than One Word")]
    public void HasMoreThanOneWordTest()
    {
        Assert.True(PlainTextToTest.HasMoreThanOneWord());
        Assert.False("PowerXtensions".HasMoreThanOneWord());
    }

    [Fact(DisplayName = "Test: Only Numbers")]
    public void OnlyNumbersTest()
    {
        Assert.Equal("9876543210", PlainTextToTest.OnlyNumbers());
        Assert.NotEqual("abc_9876543210", PlainTextToTest.OnlyNumbers());
    }

    [Fact(DisplayName = "Test: Remove")]
    public void RemoveTest()
    {
        Assert.Equal("PowerXtensions StringXtension", PlainTextToTest.Remove(" @ 9876543210"));
    }
}