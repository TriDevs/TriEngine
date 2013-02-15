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
using TriDevs.TriEngine2D.Input.Events;

namespace TriDevs.TriEngine2D.Input
{
    /// <summary>
    /// Input manager interfacing with input methods provided by a <see cref="GameWindow" />.
    /// </summary>
    public class InputManager : IInputManager
    {
        /// <summary>
        /// Raised when a key is pressed down.
        /// </summary>
        public event KeyDownEventHandler KeyDown;

        /// <summary>
        /// Raised when a key is released.
        /// </summary>
        public event KeyUpEventHandler KeyUp;

        /// <summary>
        /// Raised when a character is typed.
        /// </summary>
        public event KeyPressEventHandler KeyPress;

        /// <summary>
        /// Raised when a mouse button is pressed down.
        /// </summary>
        public event MouseDownEventHandler MouseDown;

        /// <summary>
        /// Raised when a mouse button is released.
        /// </summary>
        public event MouseUpEventHandler MouseUp;

        /// <summary>
        /// Raised when the mouse wheel value changes.
        /// </summary>
        public event MouseWheelChangedEventHandler WheelChanged;

        /// <summary>
        /// Raised when the mouse wheel is scrolled downwards.
        /// </summary>
        public event MouseWheelDownEventHandler WheelDown;

        /// <summary>
        /// Raised when the mouse wheel is scrolled upwards.
        /// </summary>
        public event MouseWheelUpEventHandler WheelUp;

        private readonly KeyboardDevice _keyboard;
        private readonly MouseDevice _mouse;

        private KeyboardState _keyboardState;
        private KeyboardState _lastKeyboardState;

        private MouseState _mouseState;
        private MouseState _lastMouseState;
        
        public int MouseX { get { return _mouse.X; } }
        public int MouseY { get { return _mouse.Y; } }
        public Point<int> MousePosition { get { return new Point<int>(MouseX, MouseY); } }
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
        /// Creates a new <see cref="InputManager" /> with only basic low-level input support.
        /// </summary>
        /// <remarks>
        /// Creating <see cref="InputManager" /> without a driver container will cause the events
        /// to be useless and never be raised, only the methods on this class will return any useful info.
        /// If you want event support, construct the InputManager with a <see cref="GameWindow" />
        /// or other supported driver providers (NYI).
        /// </remarks>
        public InputManager()
        {
            // We're assigning an empty mouse device.
            // This will make position functions return a constant 0.
            // Instead of being null and causing exceptions.
            _mouse = new MouseDevice();
            // We don't have to assign an empty keyboard device,
            // since we don't have any code that directly relies on it being present.
        }

        /// <summary>
        /// Creates a new <see cref="InputManager" /> associated with the specified <see cref="GameWindow" />.
        /// </summary>
        /// <param name="window">The <see cref="GameWindow" /> this <see cref="InputManager" /> will interface with.</param>
        public InputManager(GameWindow window)
        {
            _keyboard = window.Keyboard;
            _mouse = window.Mouse;
            _keyboard.KeyDown += OnKeyDown;
            _keyboard.KeyUp += OnKeyUp;
            window.KeyPress += OnKeyPress;
            _mouse.ButtonDown += OnMouseDown;
            _mouse.ButtonUp += OnMouseUp;
            _mouse.WheelChanged += OnMouseWheelChanged;
        }

        private void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            var func = KeyDown;
            if (func != null)
                func(this, new KeyEventArgs(e.Key));
        }

        private void OnKeyUp(object sender, KeyboardKeyEventArgs e)
        {
            var func = KeyUp;
            if (func != null)
                func(this, new KeyEventArgs(e.Key));
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            var func = KeyPress;
            if (func != null)
                func(this, new KeyCharEventArgs(e.KeyChar));
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var func = MouseDown;
            if (func != null)
                func(this, e);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var func = MouseUp;
            if (func != null)
                func(this, e);
        }

        private void OnMouseWheelChanged(object sender, MouseWheelEventArgs e)
        {
            var changeFunc = WheelChanged;
            var downFunc = WheelDown;
            var upFunc = WheelUp;

            var delta = e.DeltaPrecise;

            if (delta < 0 && downFunc != null)
                downFunc(this, e);
            else if (delta > 0 && upFunc != null)
                upFunc(this, e);

            if (changeFunc != null)
                changeFunc(this, e);
        }

        public void Update()
        {
            _lastKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();

            _lastMouseState = _mouseState;
            _mouseState = Mouse.GetState();
        }

        public bool IsKeyUp(Key key)
        {
            return !_keyboardState[key];
        }

        public bool IsKeyDown(Key key)
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

        public bool IsMouseUp(MouseButton button)
        {
            return !_mouseState[button];
        }

        public bool IsMouseDown(MouseButton button)
        {
            return _mouseState[button];
        }

        public bool MousePressed(MouseButton button)
        {
            return _mouseState[button] && !_lastMouseState[button];
        }

        public bool MouseReleased(MouseButton button)
        {
            return !_mouseState[button] && _lastMouseState[button];
        }

        public bool IsWheelUp()
        {
            return _mouseState.Wheel > _lastMouseState.Wheel;
        }

        public bool IsWheelDown()
        {
            return _mouseState.Wheel < _lastMouseState.Wheel;
        }

        public bool IsWheelChanged()
        {
            return _mouseState.Wheel != _lastMouseState.Wheel;
        }

        public int WheelChange()
        {
            return _mouseState.Wheel - _lastMouseState.Wheel;
        }
    }
}
