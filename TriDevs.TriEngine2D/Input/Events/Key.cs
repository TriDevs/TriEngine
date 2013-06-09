/* Key.cs
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
using OpenTK.Input;

namespace TriDevs.TriEngine.Input.Events
{
    /// <summary>
    /// EventArgs class used for key-related events.
    /// Contains information about the key related with the event.
    /// </summary>
    public class KeyEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="Key" /> that was involved.
        /// </summary>
        public readonly Key Key;

        internal KeyEventArgs(Key key)
        {
            Key = key;
        }
    }

    /// <summary>
    /// EventArgs class used for keychar-related events.
    /// Contains information about the character related with the event.
    /// </summary>
    public class KeyCharEventArgs : EventArgs
    {
        /// <summary>
        /// The <see cref="char" /> that was involved.
        /// </summary>
        public readonly char KeyChar;

        internal KeyCharEventArgs(char keyChar)
        {
            KeyChar = keyChar;
        }
    }

    /// <summary>
    /// Event handler delegate for the KeyDown event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e"><see cref="KeyEventArgs" /> object with information about the event.</param>
    public delegate void KeyDownEventHandler(object sender, KeyEventArgs e);

    /// <summary>
    /// Event handler delegate for the KeyUp event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e"><see cref="KeyEventArgs" /> object with information about the event.</param>
    public delegate void KeyUpEventHandler(object sender, KeyEventArgs e);

    /// <summary>
    /// Event handler delegate for the KeyPress event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e"><see cref="KeyEventArgs" /> object with information about the event.</param>
    public delegate void KeyPressEventHandler(object sender, KeyCharEventArgs e);
}
