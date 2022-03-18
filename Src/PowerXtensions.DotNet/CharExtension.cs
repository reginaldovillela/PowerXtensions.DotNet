using System;

namespace PowerXtensions.DotNet;

/// <summary>
/// Class with Byte Extensions
/// </summary>
public static class CharExtension
{
    /// <summary>
    /// Converts the Char to an Integer. If it is not possible to convert an exception will be thrown
    /// </summary>
    /// <param name="value">Char to convert</param>
    /// <returns>An Integer will be returned or an exception will be thrown</returns>
    public static int ToInt(this char value)
    {
        if (!char.IsDigit(value))
            throw new InvalidCastException("The char is not a digit");

        return value - '0';
    }
}