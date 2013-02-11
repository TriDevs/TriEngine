/* InputManager.cs
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

using OpenTK;
using OpenTK.Input;

namespace TriDevs.TriEngine2D.Input
{
    /// <summary>
    /// Input manager interfacing with input methods provided by a <see cref="GameWindow" />.
    /// </summary>
    public class InputManager : IInputManager
    {
        private readonly MouseDevice _mouse;

        private KeyboardState _keyboardState;
        private KeyboardState _lastKeyboardState;

        private MouseState _mouseState;
        private MouseState _lastMouseState;

        public int MouseX { get { return _mouse.X; } }
        public int MouseY { get { return _mouse.Y; } }
        public Point MousePosition { get { return new Point(MouseX, MouseY); } }
        public int MouseWheelValue { get { return _mouseState.Wheel; } }

        public bool this[Key key]
        {
            get { return _keyboardState[key]; }
        }

        public bool this[MouseButton button]
        {
            get { return _mouseState[button]; }
        }

        /// <summary>
        /// Creates a new <see cref="InputManager" /> associated with the specified <see cref="GameWindow" />.
        /// </summary>
        /// <param name="window">The <see cref="GameWindow" /> this <see cref="InputManager" /> will interface with.</param>
        public InputManager(GameWindow window)
        {
            _mouse = window.Mouse;
        }

        public void Update()
        {
            _lastKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();

            _lastMouseState = _mouseState;
            _mouseState = Mouse.GetState();
        }

        public bool KeyUp(Key key)
        {
            return !_keyboardState[key];
        }

        public bool KeyDown(Key key)
        {
            return _keyboardState[key];
        }

        public bool KeyPressed(Key key)
        {
            return _keyboardState[key] && !_lastKeyboardState[key];
        }

        public bool KeyReleased(Key key)
        {
            return !_keyboardState[key] && _lastKeyboardState[key];
        }

        public bool ButtonUp(MouseButton button)
        {
            return !_mouseState[button];
        }

        public bool ButtonDown(MouseButton button)
        {
            return _mouseState[button];
        }

        public bool ButtonPressed(MouseButton button)
        {
            return _mouseState[button] && !_lastMouseState[button];
        }

        public bool ButtonReleased(MouseButton button)
        {
            return !_mouseState[button] && _lastMouseState[button];
        }

        public bool WheelUp()
        {
            return _mouseState.Wheel > _lastMouseState.Wheel;
        }

        public bool WheelDown()
        {
            return _mouseState.Wheel < _lastMouseState.Wheel;
        }

        public bool WheelChanged()
        {
            return _mouseState.Wheel != _lastMouseState.Wheel;
        }

        public int WheelChange()
        {
            return _mouseState.Wheel - _lastMouseState.Wheel;
        }
    }
}
