/* Mouse.cs
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

namespace TriDevs.TriEngine.Input.Events
{
    /// <summary>
    /// Event handler delegate for the MouseDown event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse button information associated with the event.</param>
    public delegate void MouseDownEventHandler(object sender, MouseButtonEventArgs e);

    /// <summary>
    /// Event handler delegate for the MouseUp event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse button information associated with the event.</param>
    public delegate void MouseUpEventHandler(object sender, MouseButtonEventArgs e);

    /// <summary>
    /// Event handler delegate for the MouseWheelChanged event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse wheel information associated with the event.</param>
    public delegate void MouseWheelChangedEventHandler(object sender, MouseWheelEventArgs e);

    /// <summary>
    /// Event handler delegate for the MouseWheelDown event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse wheel information associated with the event.</param>
    public delegate void MouseWheelDownEventHandler(object sender, MouseWheelEventArgs e);

    /// <summary>
    /// Event handler delegate for the MouseWheelUp event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse wheel information associated with the event.</param>
    public delegate void MouseWheelUpEventHandler(object sender, MouseWheelEventArgs e);
}
