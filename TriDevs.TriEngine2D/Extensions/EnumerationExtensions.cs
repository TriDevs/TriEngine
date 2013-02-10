/* EnumerationExtensions.cs
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

/* Please note:
 * Code for the following methods written by Hugoware:
 * Include, Remove, Has, Missing
 * The class _Value was also written by Hugoware.
 * http://hugoware.net/blog/enumeration-extensions-2-0
 * Modifications done by F16Gaming: ReSharper cleanup
 */

using System;

namespace TriDevs.TriEngine2D.Extensions
{
    /// <summary>
    /// Extensions for <see cref="System.Enum" />.
    /// </summary>
    public static class EnumerationExtensions
    {
        #region Helper Classes

        //class to simplfy narrowing values between 
        //a ulong and long since either value should
        //cover any lesser value
        private class _Value
        {

            //cached comparisons for tye to use
            private static readonly Type _UInt64 = typeof(ulong);
            private static readonly Type _UInt32 = typeof(long);

            internal readonly long? Signed;
            internal readonly ulong? Unsigned;

            internal _Value(object value, Type type)
            {

                //make sure it is even an enum to work with
                if (!type.IsEnum)
                    throw new ArgumentException("Value provided is not an enumerated type!");

                //then check for the enumerated value
                var compare = Enum.GetUnderlyingType(type);

                //if this is an unsigned long then the only
                //value that can hold it would be a ulong
                try
                {
                    if (compare == _UInt32 || compare == _UInt64)
                        Unsigned = Convert.ToUInt64(value);
                    else //otherwise, a long should cover anything else
                        Signed = Convert.ToInt64(value);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Value provided is not of a supported type!");
                }
            }
        }

        #endregion

        #region Extension Methods

        /// <summary>
        /// Includes an enumerated type and returns the new value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The enum to append to.</param>
        /// <param name="append">Value to append.</param>
        /// <returns>New enum T with the new values.</returns>
        public static T Include<T>(this Enum value, T append)
        {
            var type = value.GetType();

            //determine the values
            object result = value;
            var parsed = new _Value(append, type);
            if (parsed.Signed.HasValue) //if (parsed.Signed is long)
            {
                result = Convert.ToInt64(value) | (long)parsed.Signed;
            }
            else if (parsed.Unsigned.HasValue) //else if (parsed.Unsigned is ulong)
            {
                result = Convert.ToUInt64(value) | (ulong)parsed.Unsigned;
            }

            //return the final value
            return (T)Enum.Parse(type, result.ToString());
        }

        /// <summary>
        /// Removes an enumerated type and returns the new value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The enum to remove from.</param>
        /// <param name="remove">Value to remove.</param>
        /// <returns>New enum T with the value(s) removed.</returns>
        public static T Remove<T>(this Enum value, T remove)
        {
            Type type = value.GetType();

            //determine the values
            object result = value;
            var parsed = new _Value(remove, type);
            if (parsed.Signed.HasValue) //if (parsed.Signed is long)
            {
                result = Convert.ToInt64(value) & ~(long)parsed.Signed;
            }
            else if (parsed.Unsigned.HasValue) //else if (parsed.Unsigned is ulong)
            {
                result = Convert.ToUInt64(value) & ~(ulong)parsed.Unsigned;
            }

            //return the final value
            return (T)Enum.Parse(type, result.ToString());
        }

        /// <summary>
        /// Checks if an enumerated type contains a value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The enum to check.</param>
        /// <param name="check">Value to check for.</param>
        /// <returns>True if the enum has the value(s), false otherwise.</returns>
        public static bool Has<T>(this Enum value, T check)
        {
            Type type = value.GetType();

            //determine the values
            var parsed = new _Value(check, type);
            if (parsed.Signed.HasValue) //if (parsed.Signed is long)
            {
                return (Convert.ToInt64(value) & (long)parsed.Signed) == (long)parsed.Signed;
            }
            if (parsed.Unsigned.HasValue) //if (parsed.Unsigned is ulong)
            {
                return (Convert.ToUInt64(value) & (ulong)parsed.Unsigned) == (ulong)parsed.Unsigned;
            }
            return false;
        }

        /// <summary>
        /// Checks if an enumerated type is missing a value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="obj">The enum to check.</param>
        /// <param name="value">Value to check for.</param>
        /// <returns>True if the enum is missing the value(s), false otherwise.</returns>
        public static bool Missing<T>(this Enum obj, T value)
        {
            return !Has(obj, value);
        }

        #endregion
    }
}
