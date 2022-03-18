using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerXtensions.DotNet;

/// <summary>
/// Class with Byte Extensions
/// </summary>
public static class ByteExtension
{
    /// <summary>
    /// Convert bytes to Base64
    /// </summary>
    /// <param name="value">Bytes to convert</param>
    /// <returns>String converted to Base64</returns>
    public static string Base64Encode(this byte[] value)
    {
        return Convert.ToBase64String(value);
    }
    
    /// <summary>
    /// Convert bytes to Base64
    /// </summary>
    /// <param name="value">Bytes to convert</param>
    /// <returns>String converted to Base64</returns>
    public static string Base64Encode(this IEnumerable<byte> value)
    {
        return Convert.ToBase64String(value.ToArray());
    }
}