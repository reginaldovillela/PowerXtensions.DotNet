using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PowerXtensions.DotNet
{
    public static class StringExtension
    {
        private readonly static CultureInfo _culture = CultureInfo.InvariantCulture;

        private readonly static DateTimeStyles _dtStyle = DateTimeStyles.None;

        public static string Base64Encode(this string value)
        {
            var base64EncodeBytes = Encoding.UTF8.GetBytes(value ?? "");
            return Convert.ToBase64String(base64EncodeBytes);
        }

        public static string Base64Decode(this string value)
        {
            var base64DecodeBytes = Convert.FromBase64String(value ?? "");
            return Encoding.UTF8.GetString(base64DecodeBytes);
        }

        public static string HexadecimalEncode(this string value)
        {
            var hexadecimalEncodeBytes = Encoding.UTF8.GetBytes(value ?? "");

            return string.Join("", value?.Select(c => ((int)c).ToString("X2")));
        }

        public static string HexadecimalDecode(this string value)
        {
            var bytes = new byte[value.Length / 2];

            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(value.Substring(i * 2, 2));

            return Encoding.UTF8.GetString(bytes);
        }

        #region Converters

        /// <summary>
        /// Converts the String to a DateTime. If it is not possible to convert an exception will be thrown
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <param name="format">Date and time format as is in String</param>
        /// <returns>A DateTime will be returned or an exception will be thrown</returns>
        public static DateTime ToDateTime(this string value, string format = "yyyy-mm-dd")
            => DateTime.TryParseExact(value, format, _culture, _dtStyle, out DateTime result)
            ? result
            : throw new InvalidCastException($"Unable to convert {value} value to date and time in {format} format");

        /// <summary>
        /// Converts the String to a Nullable DateTime. If it cannot convert, a null Nullable DateTime is returned
        /// </summary>
        /// <param name="value">String to be converted</param>
        /// <param name="format">Date and time format as is in String</param>
        /// <returns>A Nullable DateTime will be returned</returns>
        public static DateTime? ToNullableDateTime(this string value, string format = "yyyy-mm-dd")
            => DateTime.TryParseExact(value, format, _culture, _dtStyle, out DateTime result)
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

        /// <summary>
        /// Checks if any of the entered items exist in the String
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <param name="items">Items to find</param>
        /// <returns>If at least one of the items is found, it will return True</returns>
        public static bool Contains(this string value, params string[] items)
        {
            for (var i = 0; i < items.Length; i++)
                if (items[i] == value)
                    return true;

            return false;
        }

        /// <summary>
        /// Checks if there is more than one word in the String
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <returns>If more than one exists, True is returned.</returns>
        public static bool HasMoreThanOneWord(this string value)
            => value.Split(null).Length > 1;

        /// <summary>
        /// Checks if the String is null, empty or contains white space
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <returns>If the String is null and/or empty and/or contains white space, it will return True</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

            //if (value is null)
            //    return true;

            //if (value == "")
            //    return true;

            //if (value.StartsWith(" "))
            //    return true;

            //return false;
        }

        /// <summary>
        /// Removes all non-number characters
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <returns>Returns a String with numbers only</returns>
        public static string OnlyNumbers(this string value)
            => Regex.Replace(value ?? "", @"[^\d]", "");

        /// <summary>
        /// Remove the entered text from the String
        /// </summary>
        /// <param name="value">String for analysis</param>
        /// <param name="partToRemove">Text that will be from the String</param>
        /// <returns>Returns the string without the text entered</returns>
        public static string Remove(this string value, string partToRemove)
            => value.Replace(partToRemove, null);
    }
}