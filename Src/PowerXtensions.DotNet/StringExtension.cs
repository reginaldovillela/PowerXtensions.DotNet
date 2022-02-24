using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PowerXtensions.DotNet
{
    /// <summary>
    /// Class with string extensions
    /// </summary>
    public static class StringExtension
    {
        private readonly static CultureInfo _cultureInfo = CultureInfo.InvariantCulture;

        private readonly static DateTimeStyles _dateTimeStyle = DateTimeStyles.None;

        /// <summary>
        /// Checks if all characters are the same
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if all are the same</returns>
        public static bool AllCharactersSame(this string value)
        {
            if (value.Length <= 1)
                return true;

            var charToCompare = value[0];

            for (int i = 0; i < value.Length; i++)
                if (value[i] != charToCompare)
                    return false;
                else
                    charToCompare = value[i];

            return true;
        }

        /// <summary>
        /// Convert a Base64 to String (Plain Text)
        /// </summary>
        /// <param name="value">Base64 to convert</param>
        /// <returns>Base64 converted to String</returns>
        public static string Base64Decode(this string value)
        {
            var base64DecodeBytes = Convert.FromBase64String(value ?? "");
            return Encoding.UTF8.GetString(base64DecodeBytes);
        }

        /// <summary>
        /// Convert a String (Plain Text) to Base64
        /// </summary>
        /// <param name="value">String to convert</param>
        /// <returns>String converted to Base64</returns>
        public static string Base64Encode(this string value)
        {
            var base64EncodeBytes = Encoding.UTF8.GetBytes(value ?? "");
            return Convert.ToBase64String(base64EncodeBytes);
        }

        /// <summary>
        /// Checks if any of the entered items exist in the String
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <param name="items">Items to find</param>
        /// <returns>If at least one of the items is found, it will return True</returns>
        public static bool Contains(this string value, params string[] items)
        {
            for (var i = 0; i < items.Length; i++)
                if (value.Contains(items[i]))
                    return true;

            return false;
        }

        /// <summary>
        /// Checks if there is more than one word in the String
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <returns>If more than one exists, True is returned.</returns>
        public static bool HasMoreThanOneWord(this string value)
        {
            return value.Split().Length > 1;
        }

        /// <summary>
        /// Convert a Hexadecimal to String (Plain Text)
        /// </summary>
        /// <param name="value">Hexadecimal to convert</param>
        /// <returns>Hexadecimal converted to String</returns>
        public static string HexadecimalDecode(this string value)
        {
            var bytes = new byte[value.Length / 2];

            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);

            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Convert a String (Plain Text) to Hexadecimal
        /// </summary>
        /// <param name="value">String to convert</param>
        /// <returns>String converted to Hexadecimal</returns>
        public static string HexadecimalEncode(this string value)
        {
            return string.Join("", value.Select(c => ((int)c).ToString("x2")));
        }

        /// <summary>
        /// Checks if the String is null, empty or contains white space
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <returns>If the String is null and/or empty and/or contains white space, it will return True</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Removes all non-number characters
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <returns>Returns a String with numbers only</returns>
        public static string OnlyNumbers(this string value)
        {
            var charsNumbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var sb = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
                if (charsNumbers.Contains(value[i]))
                    sb.Append(value[i]);

            return sb.ToString();
        }

        /// <summary>
        /// Remove the entered text from the String
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <param name="partToRemove">Text that will be from the String</param>
        /// <returns>Returns the string without the text entered</returns>
        public static string Remove(this string value, string partToRemove)
        {
            return value.Replace(partToRemove, null);
        }

        #region Converters

        /// <summary>
        /// Converts the String to a DateTime. If it is not possible to convert an exception will be thrown
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <param name="format">Date and time format as is in String</param>
        /// <returns>A DateTime will be returned or an exception will be thrown</returns>
        public static DateTime ToDateTime(this string value, string format = "yyyy-mm-dd")
            => DateTime.TryParseExact(value, format, _cultureInfo, _dateTimeStyle, out DateTime result)
            ? result
            : throw new InvalidCastException($"Unable to convert {value} value to date and time in {format} format");

        /// <summary>
        /// Converts the String to a Nullable DateTime. If it cannot convert, a null Nullable DateTime is returned
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <param name="format">Date and time format as is in String</param>
        /// <returns>A Nullable DateTime will be returned</returns>
        public static DateTime? ToNullableDateTime(this string value, string format = "yyyy-mm-dd")
            => DateTime.TryParseExact(value, format, _cultureInfo, _dateTimeStyle, out DateTime result)
            ? result
            : null;

        /// <summary>
        /// Converts the String to an Integer. If unable to convert an exception will be thrown
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <returns>An Integer will be returned or an exception will be thrown</returns>
        public static int ToInt(this string value)
            => int.TryParse(value, out int result)
            ? result
            : throw new InvalidCastException($"Unable to convert the {value} value to an integer");

        /// <summary>
        /// Converts the String to a Nullable Integer. If unable to convert, a null Nullable Integer is returned
        /// </summary>
        /// <param name="value">String to be converted</param> 
        /// <returns>A Nullable Integer will be returned</returns>
        public static int? ToNullableInt(this string value)
            => int.TryParse(value, out int result)
            ? result
            : null;

        /// <summary>
        /// Converts the String to a Long. If unable to convert an exception will be thrown
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <returns>A Long will be returned or an exception will be thrown</returns>
        public static long ToLong(this string value)
            => long.TryParse(value, out long result)
            ? result
            : throw new InvalidCastException($"Unable to convert the {value} value to a long");

        /// <summary>
        /// Converts the String to a Nullable Long. If unable to convert, a null Nullable Long is returned
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <returns>A Nullable Long will be returned</returns>
        public static long? ToNullableLong(this string value)
            => long.TryParse(value, out long result)
            ? result
            : null;

        /// <summary>
        /// Converts the String to a Short. If unable to convert an exception will be thrown
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <returns>A Short will be returned or an exception will be thrown</returns>
        public static short ToShort(this string value)
            => short.TryParse(value, out short result)
            ? result
            : throw new InvalidCastException($"Unable to convert the {value} value to a short");

        /// <summary>
        /// Converts the String to a Nullable Long. If unable to convert, a null Nullable Long is returned
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <returns>A Nullable Short will be returned</returns>
        public static short? ToNullableShort(this string value)
            => short.TryParse(value, out short result)
            ? result
            : null;

        #endregion

    }
}