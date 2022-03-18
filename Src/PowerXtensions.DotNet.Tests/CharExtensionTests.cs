using System;
using Xunit;

namespace PowerXtensions.DotNet.Tests;

public class CharExtensionTests
{
    [Fact(DisplayName = "Test: Convert Char To Integer")]
    public void ToIntTests()
    {
        Assert.Equal(3, '3'.ToInt());
        Assert.Throws<InvalidCastException>(() => 'A'.ToInt());
    }
}