/* Label.cs
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

using OpenTK.Input;
using QuickFont;
using TriDevs.TriEngine2D.Text;

namespace TriDevs.TriEngine2D.UI
{
    /// <summary>
    /// A simple label to display text on the screen.
    /// </summary>
    public class Label : Control
    {
        private string _text;
        private Font _font;
        private TextObject _textObject;
        private QFontAlignment _alignment;

        private Point<int> _position;
        private Point<int> _drawPosition; 

        public override string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                UpdateTextObject();
            }
        }

        public override Point<int> Position
        {
            get { return _position; }
            set
            {
                _position = value;
                UpdateTextObject();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="QFontAlignment" />
        /// of this label's text.
        /// </summary>
        public virtual QFontAlignment Alignment
        {
            get { return _alignment; }
            set
            {
                _alignment = value;
                UpdateTextObject();
            }
        }

        /// <summary>
        /// Sets the font that this label uses.
        /// </summary>
        /// <param name="font">The new font instance to use.</param>
        public virtual void SetFont(Font font)
        {
            _font = font;
            UpdateTextObject();
        }

        protected virtual void UpdateTextObject()
        {
            if (_font == null)
                return;

            if (_textObject == null)
            {
                _textObject = new TextObject(_text, _font, Position, Alignment);
            }
            else
            {
                _textObject.Text = Text;
                _textObject.Font = _font;
                _textObject.Position = Position;
                _textObject.Alignment = Alignment;
            }

            Size = new Point<int>(_textObject.Bounds.Width, _textObject.Bounds.Height);

            switch (Alignment)
            {
                case QFontAlignment.Centre:
                    _drawPosition = new Point<int>(Position.X - Size.X / 2, Position.Y);
                    break;
                case QFontAlignment.Right:
                    _drawPosition = new Point<int>(Position.X - Size.X, Position.Y);
                    break;
                default:
                    _drawPosition = Position;
                    break;
            }
        }

        public override void Update()
        {
            // Override update logic to translate mouse click
            // positions when label is aligned in a certain way

            if (!Services.Input.MouseReleased(MouseButton.Left))
                return;

            var mousePos = Services.Input.MousePosition;
            if ((mousePos.X >= _drawPosition.X && mousePos.X <= (_drawPosition.X + Rectangle.Width))
                && (mousePos.Y >= _drawPosition.Y && mousePos.Y <= (_drawPosition.Y + Rectangle.Height)))
                OnClicked();
        }

        public override void Draw()
        {
            base.Draw(_drawPosition);

            if (_textObject == null)
                return;

            _textObject.Draw();
        }
    }
}
