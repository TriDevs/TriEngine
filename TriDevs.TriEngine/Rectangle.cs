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

using System;

namespace TriDevs.TriEngine
{
    /// <summary>
    /// A rectangle representing an area in 2D space.
    /// </summary>
    public struct Rectangle : IEquatable<Rectangle>
    {
        /// <summary>
        /// The X position of this rectangle, in screen pixels.
        /// </summary>
        public readonly int X;

        /// <summary>
        /// The Y position of this  rectangle, in screen pixels.
        /// </summary>
        public readonly int Y;

        /// <summary>
        /// The width of this rectangle in pixels.
        /// </summary>
        public readonly int Width;

        /// <summary>
        /// The height of this rectangle in pixels.
        /// </summary>
        public readonly int Height;

        /// <summary>
        /// Optional color of this rectangle, if it is to be drawn onto the screen.
        /// </summary>
        public readonly Color Color;

        /// <summary>
        /// Initializes a new <see cref="Rectangle" /> with position and size based on two
        /// point objects.
        /// </summary>
        /// <param name="position">The point to get position from.</param>
        /// <param name="size">The point to get width and height from.</param>
        /// <param name="color">Color of this rectangle, set to null for default color of black.</param>
        public Rectangle(Point<int> position, Point<int> size, Color? color = null)
            : this(position.X, position.Y, size.X, size.Y, color)
        {
            
        }

        /// <summary>
        /// Initializes a new rectangle with specified position and size. 
        /// </summary>
        /// <param name="x">X-position of this rectangle, in screen pixels.</param>
        /// <param name="y">Y-position of this rectangle, in screen pixels.</param>
        /// <param name="width">Width of this rectangle, in pixels.</param>
        /// <param name="height">Height of this rectangle, in pixels.</param>
        /// <param name="color">Color of this rectangle, set to null for default color of black.</param>
        public Rectangle(int x, int y, int width, int height, Color? color = null)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color.HasValue ? color.Value : Color.Black;
        }

        /// <summary>
        /// Returns whether this rectangle is intersecting with another rectangle.
        /// </summary>
        /// <param name="other">Rectangle to check against.</param>
        /// <returns>True if this rectangle is intersecting with the other rectangle, false otherwise.</returns>
        public bool Intersects(Rectangle other)
        {
            if (Equals(other))
                return true;

            if (X >= other.X && (X + Width) <= (other.X + other.Width))
                return true;

            if (X < other.X && (X + Width) >= other.X)
                return true;

            if (Y >= other.Y && (Y + Height) <= (other.Y + other.Height))
                return true;

            if (Y < other.Y && (Y + Height) >= other.Y)
                return true;

            return false;
        }

        public bool Equals(Rectangle other)
        {
            return X == other.X && Y == other.Y && Width == other.Width && Height == other.Height;
        }
    }
}
