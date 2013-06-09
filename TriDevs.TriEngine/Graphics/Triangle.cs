/* Triangle.cs
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

namespace TriDevs.TriEngine.Graphics
{
    /// <summary>
    /// A primitive 2D Triangle shape.
    /// </summary>
    public class Triangle : Primitive
    {
        /// <summary>
        /// Creates a new 2D Triangle with the specified points.
        /// </summary>
        /// <param name="top">Coordinate of the top edge of this triangle.</param>
        /// <param name="left">Coordinate of the lower left edge of this triangle.</param>
        /// <param name="right">Coordinate of the lower right edge of this triangle.</param>
        public Triangle(Point<int> top, Point<int> left, Point<int> right)
            : base(new ushort[] {0, 1, 2},
            new[]
            {
                new Vector3(top.X, top.Y, 0),
                new Vector3(left.X, left.Y, 0),
                new Vector3(right.X, right.Y, 0)
            },
            new[]
            {
                Color.Red, Color.Red, Color.Red
            })
        {
        }
    }
}
