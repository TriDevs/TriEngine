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

namespace TriDevs.TriEngine2D.Input
{
    /// <summary>
    /// Used as a fallback InputManager object when the service locator fails to find one.
    /// </summary>
    public class NullInputManager : IInputManager
    {
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

        public bool KeyUp(Key key)
        {
            return true;
        }

        public bool KeyDown(Key key)
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

        public bool ButtonUp(MouseButton button)
        {
            return true;
        }

        public bool ButtonDown(MouseButton button)
        {
            return false;
        }

        public bool ButtonPressed(MouseButton button)
        {
            return false;
        }

        public bool ButtonReleased(MouseButton button)
        {
            return false;
        }

        public bool WheelUp()
        {
            return false;
        }

        public bool WheelDown()
        {
            return false;
        }

        public bool WheelChanged()
        {
            return false;
        }

        public int WheelChange()
        {
            return 0;
        }
    }
}
