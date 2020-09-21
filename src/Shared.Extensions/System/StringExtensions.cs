using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodToCode.Extensions
{
    /// <summary>
    /// StringExtension
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Adds string/char if string begins with that string/char
        /// </summary>
        /// <param name="item">Item to Add part</param>
        /// <param name="toAdd">string to Add if match</param>
        /// <returns>Original item without the Addd substring</returns>
        public static string AddFirst(this string item, string toAdd)
        {
            var returnValue = item.Trim();

            if (item.IsFirst(toAdd) == false)
            {
                returnValue = (toAdd + item);
            }

            return returnValue;
        }

        /// <summary>
        /// Adds string/char if string ends with that string/char
        /// </summary>
        /// <param name="item">Item to Add part</param>
        /// <param name="toAdd">string to Add if match</param>
        /// <returns>Original item without the Addd substring</returns>
        public static string AddLast(this string item, string toAdd)
        {
            var returnValue = item.Trim();

            if (item.IsLast(toAdd) == false)
            {
                returnValue = (item + toAdd);
            }

            return returnValue;
        }

        /// <summary>
        /// Is this item an email address?
        /// </summary>
        /// <param name="item">Item to validate</param>
        /// <param name="emptyStringOK">Flags an empty string as valid, even though it is not an email address</param>
        /// <returns>True if this is an email address (or if empty.)</returns>
        public static bool IsEmail(this string item, bool emptyStringOK = true)
        {
            var returnValue = false;

            item = item.Trim();
            if ((emptyStringOK == true & item.Length == 0))
            {
                returnValue = true;
            }
            else
            {
                if ((item.Contains("@") & item.Contains("."))
                    && (item.IndexOf(".", item.IndexOf("@")) > item.IndexOf("@"))
                    && (item.Contains(" ") == false)
                    && (item.SubstringSafe(item.IndexOf("@") + 1).Contains("@") == false))
                {
                    returnValue = true;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Is the first character(s) equal to the passed characters?
        /// </summary>
        /// <param name="item">Item to validate</param>
        /// <param name="firstCharacters">Character to look for</param>
        /// <returns>True/False if found characters in position</returns>
        public static bool IsFirst(this string item, string firstCharacters)
        {
            var returnValue = false;

            if (item.Length >= firstCharacters.Length)
            {
                if (item.SubstringSafe(0, firstCharacters.Length) == firstCharacters)
                {
                    returnValue = true;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Is this item an integer?
        /// </summary>
        /// <param name="item">Item to validate</param>
        /// <returns>True if this is an integer.</returns>
        public static bool IsInteger(this string item)
        {
            var returnValue = false;

            if (item.ToInt64() != -1)
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Is the last character(s) equal to the passed characters?
        /// </summary>
        /// <param name="item">Item to validate</param>
        /// <param name="lastCharacters">Character to look for</param>
        /// <returns>True/False if found characters in position</returns>
        public static bool IsLast(this string item, string lastCharacters)
        {
            var returnValue = false;

            if (item.Length >= lastCharacters.Length)
            {
                if (item.SubstringRight(lastCharacters.Length) == lastCharacters)
                {
                    returnValue = true;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Removes string/char if string begins with that string/char
        /// </summary>
        /// <param name="item">Item to remove part</param>
        /// <param name="toRemove">string to remove if match</param>
        /// <returns>Original item without the removed substring</returns>
        public static string RemoveFirst(this string item, string toRemove)
        {
            var returnValue = item.Trim();

            if (item.IsFirst(toRemove))
            {
                returnValue = item.SubstringRight(item.Length - toRemove.Length);
            }

            return returnValue;
        }

        /// <summary>
        /// Removes string/char if string ends with that string/char
        /// </summary>
        /// <param name="item">Item to remove part</param>
        /// <param name="toRemove">string to remove if match</param>
        /// <returns>Original item without the removed substring</returns>
        public static string RemoveLast(this string item, string toRemove)
        {
            var returnValue = item.Trim();

            if (item.IsLast(toRemove))
            {
                returnValue = item.SubstringLeft(item.Length - toRemove.Length);
            }

            return returnValue;
        }

        /// <summary>
        /// Converts a string to Boolean
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <returns>Converted or not found value of the source item</returns>
        public static bool ToBoolean(this string item)
        {
            var returnValue = default(bool);
            if (String.IsNullOrEmpty(item) == false)
            {
                bool convertValue;
                if (item.ToInt16() != -1) // Catch integers, as To only evaluates "true" and "false", not "0".
                {
                    returnValue = item.ToInt16() == 0 ? false : true;
                }
                else if (Boolean.TryParse(item, out convertValue))
                {
                    returnValue = convertValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Converts a string to Int16
        /// </summary>
        /// <param name="item">Source item to convert</param>        
        /// <returns>Converted or not found value of the source item</returns>
        public static short ToInt16(this string item)
        {
            var returnValue = default(short);

            // Try to parse it out
            if (String.IsNullOrEmpty(item) == false)
            {
                if (Int16.TryParse(item, out short convertValue))
                {
                    returnValue = convertValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Converts a string to int
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <param name="notFoundValue">Value if not found</param>
        /// <returns>Converted or not found value of the source item</returns>
        public static int ToInt32(this string item)
        {
            var returnValue = default(int);
            if (String.IsNullOrEmpty(item) == false)
            {
                if (int.TryParse(item, out int convertValue))
                {
                    returnValue = convertValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Converts a string to Int64
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <param name="notFoundValue">Value if not found</param>
        /// <returns>Converted or not found value of the source item</returns>
        public static long ToInt64(this string item)
        {
            var returnValue = default(long);
            if (String.IsNullOrEmpty(item) == false)
            {
                if (Int64.TryParse(item, out long convertValue))
                {
                    returnValue = convertValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Converts string to Guid
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <param name="notFoundValue">Value if not found</param>
        /// <returns>Converted or not found value of the source item</returns>
        public static Guid ToGuid(this string item)
        {
            var returnValue = default(Guid);

            if (String.IsNullOrEmpty(item) == false)
            {
                if(!Guid.TryParse(item, out returnValue))
                    returnValue = default(Guid);
            }

            return returnValue;
        }

        /// <summary>
        /// Converts string to decimal
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <param name="notFoundValue">Value if not found</param>
        /// <returns>Converted or not found value of the source item</returns>
        public static decimal ToDecimal(this string item)
        {
            var returnValue = default(decimal);
            if (String.IsNullOrEmpty(item) == false)
            {
                if (Decimal.TryParse(item, out decimal convertValue))
                {
                    returnValue = convertValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Converts string to double
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <param name="notFoundValue">Value if not found</param>
        /// <returns>Converted or not found value of the source item</returns>
        public static double ToDouble(this string item)
        {
            var returnValue = default(double);
            if (String.IsNullOrEmpty(item) == false)
            {
                double convertValue;
                if (Double.TryParse(item, out convertValue))
                {
                    returnValue = convertValue;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Converts string to double
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <param name="notFoundValue">Value if not found</param>
        /// <returns>Converted or not found value of the source item</returns>
        public static TEnum ToEnum<TEnum>(this string item, TEnum notFoundValue)
        {
            var returnValue = default(TEnum);

            try
            {
                if (String.IsNullOrEmpty(item) == false)
                {
                    returnValue = (TEnum)Enum.Parse(typeof(TEnum), item, true);
                }
            }
            catch (ArgumentException)
            {
                returnValue = notFoundValue;
            }
            catch (OverflowException)
            {
                returnValue = notFoundValue;
            }

            return returnValue;
        }

        /// <summary>
        /// Converts string to DateTime
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <returns>Converted or not found value (01/01/1900) of the source item</returns>
        public static DateTime ToDateTime(this string item)
        {
            var returnValue = default(DateTime);            
            item = item.Trim();
            if (item.IsInteger() == true & item.Length == 8)
                item = item.Substring(0, 2) + "-" + item.Substring(2, 2) + "-" + item.Substring(4, 4);
            if ((!(String.IsNullOrEmpty(item))) & (item.Trim().Length >= 8))
                if (DateTime.TryParse(item, out DateTime convertDate))
                    returnValue = convertDate;

            return returnValue;
        }

        /// <summary>
        /// Converts string to Uri
        /// </summary>
        /// <param name="item">Source item to convert</param>
        /// <returns>Converted value if success. 
        /// Failure returns http://localhost:80, value of Default.Uri</returns>
        public static Uri ToUri(this string item)
        {
            var returnValue = new Uri("http://localhost:80", UriKind.RelativeOrAbsolute);

            if (String.IsNullOrEmpty(item) == false)
            {
                try
                {
                    returnValue = new Uri(item);
                }
                catch
                {
                    returnValue = new Uri("http://localhost:80", UriKind.RelativeOrAbsolute);
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Pulls right characters from a String
        /// </summary>
        /// <param name="item">Item to extract right characters</param>
        /// <param name="rightCharacters">Number of characters, starting from the right</param>
        /// <returns>Characters or original string, starting from the right</returns>
        public static string SubstringRight(this string item, int rightCharacters)
        {
            return item.SubstringSafe(item.Length - rightCharacters);
        }

        /// <summary>
        /// Pulls left characters from a String
        /// </summary>
        /// <param name="item">Item to extract left characters</param>
        /// <param name="leftCharacters">Number of characters, starting from the left</param>
        /// <returns>Characters or original string, starting from the left</returns>
        public static string SubstringLeft(this string item, int leftCharacters)
        {
            return item.SubstringSafe(0, leftCharacters);
        }

        /// <summary>
        /// Extracts substring exception-safe
        /// </summary>
        /// <param name="item">Item to extract the substring</param>
        /// <param name="starting">Starting position</param>
        /// <param name="length">Number of characters to try to extract</param>
        /// <returns>Extracted characters, or original string if cant substring.</returns>
        public static string SubstringSafe(this string item, int starting, int length = -1)
        {
            var itemLength = item.Length;

            if (length == -1) length = itemLength - starting;
            string returnValue;
            if (itemLength > length - (starting + 1))
            {
                returnValue = length > -1 ? item.Substring(starting, length) : item.Substring(starting);
            }
            else
            {
                returnValue = itemLength == length - (starting + 1) ? item.Substring(starting, length - 1) : item;
            }

            return returnValue;
        }

        /// <summary>
        /// Splits a CSV into a list
        /// </summary>
        /// <param name="item">CSV string to convert to a list</param>
        /// <param name="separator">Character that separates the elements. Default is comma ','</param>
        /// <returns></returns>
        public static List<string> Split(this string item, char separator = ',')
        {
            var returnValue = new List<string>();
            if (!string.IsNullOrWhiteSpace(item))
            {
                returnValue = item
                    .TrimEnd(separator)
                    .Split(separator)
                    .AsEnumerable<string>()
                    .Select(s => s.Trim())
                    .ToList();
            }
            return returnValue;
        }
    }
}