/* NullInputManager.cs
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
using TriDevs.TriEngine2D.Input.Events;

namespace TriDevs.TriEngine2D.Input
{
    /// <summary>
    /// Used as a fallback InputManager object when the service locator fails to find one.
    /// </summary>
    public class NullInputManager : IInputManager
    {
        /// <summary>
        /// Raised when a key is pressed down.
        /// </summary>
        /// <remarks>
        /// This particular event is never raised,
        /// it's merely a placeholder in case a proper InputManager was not supplied.
        /// </remarks>
        public event KeyDownEventHandler KeyDown;

        /// <summary>
        /// Raised when a key is released.
        /// </summary>
        /// <remarks>
        /// This particular event is never raised,
        /// it's merely a placeholder in case a proper InputManager was not supplied.
        /// </remarks>
        public event KeyUpEventHandler KeyUp;

        /// <summary>
        /// Raised when a character is typed.
        /// </summary>
        /// <remarks>
        /// This particular event is never raised,
        /// it's merely a placeholder in case a proper InputManager was not supplied.
        /// </remarks>
        public event KeyPressEventHandler KeyPress;

        /// <summary>
        /// Raised when a mouse button is pressed down.
        /// </summary>
        /// <remarks>
        /// This particular event is never raised,
        /// it's merely a placeholder in case a proper InputManager was not supplied.
        /// </remarks>
        public event MouseDownEventHandler MouseDown;

        /// <summary>
        /// Raised when a mouse button is released.
        /// </summary>
        /// <remarks>
        /// This particular event is never raised,
        /// it's merely a placeholder in case a proper InputManager was not supplied.
        /// </remarks>
        public event MouseUpEventHandler MouseUp;

        /// <summary>
        /// Raised when the mouse wheel value changes.
        /// </summary>
        /// <remarks>
        /// This particular event is never raised,
        /// it's merely a placeholder in case a proper InputManager was not supplied.
        /// </remarks>
        public event MouseWheelChangedEventHandler WheelChanged;

        /// <summary>
        /// Raised when the mouse wheel is scrolled downwards.
        /// </summary>
        /// <remarks>
        /// This particular event is never raised,
        /// it's merely a placeholder in case a proper InputManager was not supplied.
        /// </remarks>
        public event MouseWheelDownEventHandler WheelDown;

        /// <summary>
        /// Raised when the mouse wheel is scrolled upwards.
        /// </summary>
        /// <remarks>
        /// This particular event is never raised,
        /// it's merely a placeholder in case a proper InputManager was not supplied.
        /// </remarks>
        public event MouseWheelUpEventHandler WheelUp;

        public int MouseX { get { return 0; } }
        public int MouseY { get { return 0; } }
        public Point<int> MousePosition { get { return new Point<int>(0, 0); } }
        public int MouseWheelValue { get { return 0; } }

        public bool this[Key key]
        {
            get { return false; }
        }

        public bool this[MouseButton button]
        {
            get { return false; }
        }

        public void Update()
        {
            // Do nothing
        }

        public bool IsKeyUp(Key key)
        {
            return true;
        }

        public bool IsKeyDown(Key key)
        {
            return false;
        }

        public bool KeyPressed(Key key)
        {
            return false;
        }

        public bool KeyReleased(Key key)
        {
            return false;
        }

        public bool IsMouseUp(MouseButton button)
        {
            return true;
        }

        public bool IsMouseDown(MouseButton button)
        {
            return false;
        }

        public bool MousePressed(MouseButton button)
        {
            return false;
        }

        public bool MouseReleased(MouseButton button)
        {
            return false;
        }

        public bool IsWheelUp()
        {
            return false;
        }

        public bool IsWheelDown()
        {
            return false;
        }

        public bool IsWheelChanged()
        {
            return false;
        }

        public int WheelChange()
        {
            return 0;
        }
    }
}
