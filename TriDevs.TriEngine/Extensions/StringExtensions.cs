/* StringExtensions.cs
 *
 * Copyright © 2013 by Adam Hellberg, Sijmen Schoon and Preston Shumway.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System.Text.RegularExpressions;

namespace TriDevs.TriEngine.Extensions
{
    /// <summary>
    /// Extensions for <see cref="System.String" />
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a string in which the first occurrence of a specified string is replaced with another string.
        /// </summary>
        /// <param name="s">String to modify.</param>
        /// <param name="search">String to search for.</param>
        /// <param name="replace">String to replace the match with.</param>
        /// <param name="caseInsensitive">True for case insensitive search, false for case sensitive.</param>
        /// <returns>The supplied string with the first occurrence of the specified string replaced with the other.</returns>
        public static string ReplaceFirst(this string s, string search, string replace, bool caseInsensitive = false)
        {
            return Replace(s, search, replace, 1, caseInsensitive);
        }

        /// <summary>
        /// Returns a string in which the N first occurrences of a specified string are replaced with another string.
        /// </summary>
        /// <param name="s">String to modify.</param>
        /// <param name="search">String to search for.</param>
        /// <param name="replace">String to replace the match(es) with.</param>
        /// <param name="count">Number of occurrences to replace.</param>
        /// <param name="caseInsensitive">True for case insensitive search, false for case sensitive.</param>
        /// <returns>The supplied string with the N first occurrences of the specified string replaced with the other.</returns>
        public static string Replace(this string s, string search, string replace, int count, bool caseInsensitive = false)
        {
            var re = caseInsensitive ? new Regex(search, RegexOptions.IgnoreCase) : new Regex(search);
            return re.Replace(s, replace, count);
        }

        /// <summary>
        /// Returns a string in which all occurrences of a specified string are replaced with another string.
        /// </summary>
        /// <remarks>
        /// This extension method supports case insensitive searches.
        /// </remarks>
        /// <param name="s">String to modify.</param>
        /// <param name="search">String to search for.</param>
        /// <param name="replace">String to replace the match(es) with.</param>
        /// <param name="caseInsensitive">True for case insensitive search, false for case sensitive.</param>
        /// <returns>The supplied string with all occurrences of the specified string replaced with the other.</returns>
        public static string Replace(this string s, string search, string replace, bool caseInsensitive = false)
        {
            var re = caseInsensitive ? new Regex(search, RegexOptions.IgnoreCase) : new Regex(search);
            return re.Replace(s, replace);
        }
    }
}
