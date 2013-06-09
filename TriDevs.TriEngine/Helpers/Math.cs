/* Math.cs
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

using System;

namespace TriDevs.TriEngine.Helpers
{
    /// <summary>
    /// Various helper methods for working with math.
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Clamps the specified byte between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified byte is below this value, then this will be returned.</param>
        /// <param name="max">If the specified byte is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the byte.</returns>
        public static byte Clamp(byte value, byte min, byte max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified short between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified short is below this value, then this will be returned.</param>
        /// <param name="max">If the specified short is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the short.</returns>
        public static short Clamp(short value, short min, short max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified unsigned short between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified unsigned short is below this value, then this will be returned.</param>
        /// <param name="max">If the specified unsigned short is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the unsigned short.</returns>
        public static ushort Clamp(ushort value, ushort min, ushort max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified integer between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified integer is below this value, then this will be returned.</param>
        /// <param name="max">If the specified integer is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the integer.</returns>
        public static int Clamp(int value, int min, int max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified unsigned integer between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified unsigned integer is below this value, then this will be returned.</param>
        /// <param name="max">If the specified unsigned integer is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the unsigned integer.</returns>
        public static uint Clamp(uint value, uint min, uint max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified 64-bit integer between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified 64-bit integer is below this value, then this will be returned.</param>
        /// <param name="max">If the specified 64-bit integer is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the 64-bit integer.</returns>
        public static long Clamp(long value, long min, long max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified 64-bit unsigned integer between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified 64-bit unsigned integer is below this value, then this will be returned.</param>
        /// <param name="max">If the specified 64-bit unsigned integer is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the 64-bit unsigned integer.</returns>
        public static ulong Clamp(ulong value, ulong min, ulong max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified float between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified float is below this value, then this will be returned.</param>
        /// <param name="max">If the specified float is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the float.</returns>
        public static float Clamp(float value, float min, float max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified double between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified double is below this value, then this will be returned.</param>
        /// <param name="max">If the specified double is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the double.</returns>
        public static double Clamp(double value, double min, double max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be greater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Clamps the specified decimal between a minimum and maximum value.
        /// </summary>
        /// <param name="value">Value to clamp.</param>
        /// <param name="min">If the specified decimal is below this value, then this will be returned.</param>
        /// <param name="max">If the specified decimal is above this value, then this will be returned.</param>
        /// <returns>The clamped value of the decimal.</returns>
        public static decimal Clamp(decimal value, decimal min, decimal max)
        {
            if (min > max)
                throw new ArgumentException("Minimum value cannot be grater than maximum value.", "min");

            return value < min ? min : (value > max ? max : value);
        }
    }
}
