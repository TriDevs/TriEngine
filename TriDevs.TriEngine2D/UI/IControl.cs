/* IControl.cs
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TriDevs.TriEngine2D.UI.Events;

namespace TriDevs.TriEngine2D.UI
{
    /// <summary>
    /// A UI control that can be drawn on screen and interacted with.
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// Raised when this control is clicked on by the user.
        /// </summary>
        event ControlClickedEventHandler Clicked;

        /// <summary>
        /// Gets or sets a value indicating whether this control can be interacted with.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this control should be drawn to the screen.
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// The color of this control.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// The position of this control, in pixel coordinates.
        /// </summary>
        Point<int> Position { get; set; }

        /// <summary>
        /// Gets or sets the size of this control, in pixels.
        /// </summary>
        Point<int> Size { get; set; } 

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Enables the control.
        /// </summary>
        void Enable();

        /// <summary>
        /// Disables the control.
        /// </summary>
        void Disable();

        /// <summary>
        /// Shows the control.
        /// </summary>
        void Show();

        /// <summary>
        /// Hides the control.
        /// </summary>
        void Hide();
    }
}
