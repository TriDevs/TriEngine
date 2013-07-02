/* TextObject.cs
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
using OpenTK;
using QuickFont;

namespace TriDevs.TriEngine.Text
{
    /// <summary>
    /// Implements the ITextObject interface.
    /// </summary>
    public class TextObject : ITextObject
    {
        private Vector2 _vectorPos;
        private Rectangle _bounds;
        private QFontAlignment _alignment;
        private string _text;

        public Font Font { get; set; }
        public Color Color { get; set; }

        public string Text
        {
            get { return _text; }
            set { _text = value ?? string.Empty; }
        }

        public Point<int> Position
        {
            get { return new Point<int>((int) _vectorPos.X, (int) _vectorPos.Y); }
            set
            {
                _vectorPos = new Vector2(value.X, value.Y);
                CalculateBounds();
            }
        }

        public Rectangle Bounds { get { return _bounds; } }

        public QFontAlignment Alignment
        {
            get { return _alignment; }
            set
            {
                _alignment = value;
                CalculateBounds();
            }
        }

        public TextObject(string text, string fontName, Point<int> position = new Point<int>(),
                          QFontAlignment alignment = QFontAlignment.Centre)
            : this(text, Resources.ResourceManager.Get<Font>(fontName), position, alignment)
        {
            
        }

        /// <summary>
        /// Initializes a new <see cref="TextObject" /> instance.
        /// </summary>
        /// <param name="text">The initial text to set for this text object.</param>
        /// <param name="font">The font to use for this text object.</param>
        /// <param name="position">The intitial position of this text object.</param>
        /// <param name="alignment">The intitial alignment of the text in this text object.</param>
        public TextObject(string text, Font font, Point<int> position = new Point<int>(),
                          QFontAlignment alignment = QFontAlignment.Centre)
        {
            if (font == null)
                throw new EngineException("Font supplied for TextObject is null!", new ArgumentNullException("font"));

            Text = text;
            Font = font;
            Position = position;
            Alignment = alignment;
        }

        private void CalculateBounds()
        {
            var size = Font.QFont.Measure(Text, Alignment);
            _bounds = new Rectangle((int) _vectorPos.X, (int) _vectorPos.Y, (int) size.Width, (int) size.Height);
        }

        public void Draw()
        {
            Draw(_vectorPos);
        }

        public void Draw(Point<int> position)
        {
            Draw(position.X, position.Y);
        }

        public void Draw(int x, int y)
        {
            Draw(new Vector2(x, y));
        }

        private void Draw(Vector2 pos)
        {
            QFont.Begin();
            Font.QFont.Print(Text, Alignment, pos);
            QFont.End();
        }
    }
}
