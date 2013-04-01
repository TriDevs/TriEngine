/* Rectangle.cs
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

namespace TriDevs.TriEngine2D.Graphics
{
    /// <summary>
    /// A primitive 2D Rectangle shape.
    /// </summary>
    public class Rectangle : Primitive
    {
        /// <summary>
        /// Creates a new 2D Rectangle with the specified settings.
        /// </summary>
        /// <param name="rect">The rectangle defining the position and size of this primitive.</param>
        public Rectangle(TriEngine2D.Rectangle rect)
            : base(new ushort[]
            {
                // First triangle
                0, 1, 2,

                // Second triangle
                0, 2, 3
            }, 
            new[]
            {
                // Top left
                new Vector3(rect.X, rect.Y, 0),

                // Bottom left
                new Vector3(rect.X, rect.Y + rect.Height, 0),

                // Bottom right
                new Vector3(rect.X + rect.Width, rect.Y + rect.Height, 0),
                
                // Top right
                new Vector3(rect.X + rect.Width, rect.Y, 0)
            })
        {
        }
    }
}
