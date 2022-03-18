using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PowerXtensions.DotNet.Tests;

public class ByteExtensionTests
{
    [Fact(DisplayName = "Test: Convert Bytes To Base64")]
    public void Base64EncodeTests()
    {
        var aBytes = Encoding.UTF8.GetBytes("PowerXtensions.DotNet");
        var eBytes = (IEnumerable<byte>) aBytes;

        Assert.Equal("UG93ZXJYdGVuc2lvbnMuRG90TmV0", aBytes.Base64Encode());
        Assert.Equal("UG93ZXJYdGVuc2lvbnMuRG90TmV0", eBytes.Base64Encode());
    }
}