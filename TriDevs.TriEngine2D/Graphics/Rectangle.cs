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

using System;
using TriDevs.TriEngine2D.Interfaces;

namespace TriDevs.TriEngine2D.Graphics
{
    public class Rectangle : IDrawable, IDisposable
    {
        public Triangle LeftTriangle { get; private set; }
        public Triangle RightTriangle { get; private set; }

        public Rectangle(TriEngine2D.Rectangle rect)
        {
            LeftTriangle = new Triangle(new Point<int>(rect.X, rect.Y), new Point<int>(rect.X, rect.Y + rect.Height),
                                        new Point<int>(rect.X + rect.Width, rect.Y + rect.Height));
            RightTriangle = new Triangle(new Point<int>(rect.X, rect.Y),
                                         new Point<int>(rect.X + rect.Width, rect.Y + rect.Height),
                                         new Point<int>(rect.X + rect.Width, rect.Y));
        }

        public void Draw()
        {
            LeftTriangle.Draw();
            RightTriangle.Draw();
        }

        public void Dispose()
        {
            LeftTriangle.Dispose();
            RightTriangle.Dispose();
        }
    }
}
