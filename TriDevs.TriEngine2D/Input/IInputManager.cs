/* IInputManager.cs
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
    /// Provides various methods to query input devices like the keyboard.
    /// </summary>
    public interface IInputManager
    {
        /// <summary>
        /// Gets the absolute X position of the pointer,
        /// in window pixel coordinates.
        /// </summary>
        int MouseX { get; }

        /// <summary>
        /// Gets the absolute Y position of the pointer,
        /// in window pixel coordinates.
        /// </summary>
        int MouseY { get; }

        /// <summary>
        /// Gets a <see cref="Point" /> representing the position of the mouse pointer,
        /// in window pixel coordinates.
        /// </summary>
        Point MousePosition { get; }

        /// <summary>
        /// Gets the current value of the mouse wheel.
        /// </summary>
        int MouseWheelValue { get; }

        /// <summary>
        /// Gets a boolean value indicating whether the specified <see cref="OpenTK.Input.Key" /> is pressed.
        /// </summary>
        /// <param name="key">The key to query.</param>
        /// <returns>True if pressed, false otherwise.</returns>
        bool this[Key key] { get; }

        /// <summary>
        /// Gets a boolean value indicating whether the specified <see cref="OpenTK.Input.MouseButton" /> is pressed.
        /// </summary>
        /// <param name="button">The button to query.</param>
        /// <returns>True if pressed, false otherwise.</returns>
        bool this[MouseButton button] { get; }

        /// <summary>
        /// Updates the input manager, refreshing all current and previous states.
        /// </summary>
        void Update();

        /// <summary>
        /// Returns whether or not the specified key is currently unpressed.
        /// </summary>
        /// <param name="key">Key to query for.</param>
        /// <returns>True if the key is currently up (not pressed), false otherwise.</returns>
        bool KeyUp(Key key);

        /// <summary>
        /// Returns whether or not the specified key is currently being pressed.
        /// </summary>
        /// <param name="key">Key to query for.</param>
        /// <returns>True if key is currently being pressed, false otherwise.</returns>
        bool KeyDown(Key key);
        
        /// <summary>
        /// Returns whether or not the specified key has been pressed.
        /// </summary>
        /// <remarks>
        /// Only returns true if the last state of the key was not pressed.
        /// </remarks>
        /// <param name="key">Key to query for.</param>
        /// <returns>True if key was pressed, false otherwise.</returns>
        bool KeyPressed(Key key);

        /// <summary>
        /// Returns whether or not the specified key has been released.
        /// </summary>
        /// <remarks>
        /// Only returns true if the last state of the key was pressed.
        /// </remarks>
        /// <param name="key">Key to query for.</param>
        /// <returns>True if key was released, false otherwise.</returns>
        bool KeyReleased(Key key);

        /// <summary>
        /// Returns whether or not the specified mouse button is currently unpressed.
        /// </summary>
        /// <param name="button">Button to query for.</param>
        /// <returns>True if the button is currently up (not pressed), false otherwise.</returns>
        bool ButtonUp(MouseButton button);

        /// <summary>
        /// Returns whether or not the specified mouse button is currently being pressed.
        /// </summary>
        /// <param name="button">The button to query for.</param>
        /// <returns>True if button is currently being pressed, false otherwise.</returns>
        bool ButtonDown(MouseButton button);

        /// <summary>
        /// Returns whether or not the specified mouse button has been pressed.
        /// </summary>
        /// <remarks>
        /// Only returns true if the last state of the mouse button was not pressed.
        /// </remarks>
        /// <param name="button">Button to query for.</param>
        /// <returns>True if button was pressed, false otherwise.</returns>
        bool ButtonPressed(MouseButton button);

        /// <summary>
        /// Returns whether or not the specified mouse button has been released.
        /// </summary>
        /// <remarks>
        /// Only returns true if the last state of the button was pressed.
        /// </remarks>
        /// <param name="button">The button to query for.</param>
        /// <returns>True if the button was released, false otherwise.</returns>
        bool ButtonReleased(MouseButton button);

        /// <summary>
        /// Returns whether the mouse wheel was scrolled up.
        /// </summary>
        /// <returns>True if mouse wheel was scrolled up, false otherwise.</returns>
        bool WheelUp();

        /// <summary>
        /// Returns whether the mouse wheel was scrolled down.
        /// </summary>
        /// <returns>True if mouse wheel was scrolled down, false otherwise.</returns>
        bool WheelDown();

        /// <summary>
        /// Returns whether the mouse wheel scrolled at all.
        /// </summary>
        /// <returns>True if the mouse wheel scrolled, false otherwise.</returns>
        bool WheelChanged();

        /// <summary>
        /// Returns the mouse wheel's change in value.
        /// </summary>
        /// <returns>Negative value if wheel scrolled down, positive value if scrolled up, zero if not scrolled.</returns>
        int WheelChange();
    }
}
