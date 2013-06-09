/* ITextObject.cs
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

using QuickFont;

namespace TriDevs.TriEngine.Text
{
    /// <summary>
    /// Implements methods to construct a text object and render it to screen.
    /// </summary>
    public interface ITextObject
    {
        /// <summary>
        /// Gets the <see cref="Font" /> font instance associated with this text object.
        /// </summary>
        Font Font { get; }

        /// <summary>
        /// Gets or sets the text value of this text object.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Gets or sets the screen position of this text, in pixels.
        /// </summary>
        Point<int> Position { get; set; }

        /// <summary>
        /// Gets the bounds of this text object.
        /// </summary>
        Rectangle Bounds { get; }

        /// <summary>
        /// Gets or sets a <see cref="QFontAlignment" /> value to
        /// manage how this text is aligned on screen.
        /// </summary>
        QFontAlignment Alignment { get; set; }

        /// <summary>
        /// Draws this text object to screen with default parameters.
        /// </summary>
        void Draw();

        /// <summary>
        /// Draws this text object to a specific position on the screen
        /// specified by the supplied Point struct.
        /// </summary>
        /// <param name="position">Point class with X/Y coordinates.</param>
        void Draw(Point<int> position);

        /// <summary>
        /// Draws this text oject to screen at the specified X/Y position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Draw(int x, int y);
    }
}
