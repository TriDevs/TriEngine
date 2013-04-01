/* Vector3Extensions.cs
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

using OpenTK;

namespace TriDevs.TriEngine2D.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Vector3" />.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Converts an array of <see cref="Vector3" /> into
        /// a float array (3 floats per vector).
        /// </summary>
        /// <param name="vectors">The vector array to convert.</param>
        /// <returns>A float array representation of the vectors.</returns>
        public static float[] ToFloatArray(this Vector3[] vectors)
        {
            var result = new float[3 * vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                int index = i * 3;

                result[index] = vectors[i].X;
                result[index + 1] = vectors[i].Y;
                result[index + 2] = vectors[i].Z;
            }

            return result;
        }
    }
}
