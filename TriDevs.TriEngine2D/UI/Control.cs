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

        public virtual string Text { get; set; }

        protected virtual void OnClicked()
        {
            var func = Clicked;
            if (func != null)
                func(this, null);
        }

        /// <summary>
        /// This method is used to raise the click event from internal engine code.
        /// Seeing as controls do not currently have a way to detect clicks on their own.
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
    }
}
