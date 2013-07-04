/* Point.cs
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

namespace TriDevs.TriEngine
{
    /// <summary>
    /// A struct representing an X/Y/Z coordinate.
    /// </summary>
    /// <typeparam name="T">The type used for the X, Y and Z members.</typeparam>
    public struct Point<T> where T : struct
    {
        /// <summary>
        /// The X value of the coordinate.
        /// </summary>
        public T X;

        /// <summary>
        /// The Y value of the coordinate.
        /// </summary>
        public T Y;

        /// <summary>
        /// The Z value of the coordinate.
        /// </summary>
        public T Z;

        /// <summary>
        /// Creates a new <see cref="Point&lt;T&gt;" /> with the specified X and Y values.
        /// </summary>
        /// <param name="x">The X value.</param>
        /// <param name="y">The Y value.</param>
        /// <param name="z">The Z value.</param>
        public Point(T x, T y, T z = default(T))
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
