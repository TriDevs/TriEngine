/* Control.cs
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
using TriDevs.TriEngine2D.UI.Events;

namespace TriDevs.TriEngine2D.UI
{
    /// <summary>
    /// Base control class that all other controls inherits from.
    /// Defines basic UI control behaviour.
    /// </summary>
    public abstract class Control : IControl
    {
        /// <summary>
        /// Raised when this control is clicked on by the user.
        /// </summary>
        public event ControlClickedEventHandler Clicked;

        public virtual bool Enabled { get; set; }

        public virtual bool Visible { get; set; }

        public virtual Color Color { get; set; }

        public virtual Point<int> Position { get; set; }
        
        public virtual Point<int> Size { get; set; }

        public virtual Rectangle Rectangle
        {
            get { return new Rectangle(Position, Size); }
            set
            {
                Position = new Point<int>(value.X, value.Y);
                Size = new Point<int>(value.Width, value.Height);
            }
        }

        public virtual string Text { get; set; }

        protected virtual void OnClicked()
        {
            var func = Clicked;
            if (func != null)
                func(this, null);
        }

        /// <summary>
        /// This method is used to raise the click event from internal engine code.
        /// Normally the Control.Update method handles this, only use this if clicks
        /// have to be manually detected outside of normal update calls.
        /// </summary>
        internal void Click()
        {
            OnClicked();
        }

        public virtual void Enable()
        {
            Enabled = true;
        }

        public virtual void Disable()
        {
            Enabled = false;
        }

        public virtual void Show()
        {
            Visible = true;
        }

        public virtual void Hide()
        {
            Visible = false;
        }

        public virtual void Update()
        {
            // Return immediately if there is no mouse click
            // We only run the click handlers if the user has is releasing
            // the mouse button while on a control, to mimic how most UIs
            // handle click events.
            if (!Services.Input.MouseReleased(MouseButton.Left))
                return;

            var mousePos = Services.Input.MousePosition;
            // "Cache" the rectangle so we don't create a new one each time we want a value
            var rect = Rectangle;
            if ((mousePos.X >= rect.X && mousePos.X <= (rect.X + rect.Width))
                || (mousePos.Y >= rect.Y && mousePos.Y <= (rect.Y + rect.Height)))
                OnClicked();
        }

        public virtual void Draw()
        {

        }
    }
}
