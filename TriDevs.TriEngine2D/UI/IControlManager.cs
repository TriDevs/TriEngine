/* IControlManager.cs
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
using TriDevs.TriEngine2D.Interfaces;

namespace TriDevs.TriEngine2D.UI
{
    /// <summary>
    /// Manages various UI controls, automatically updating and drawing them to the screen.
    /// </summary>
    public interface IControlManager : IDrawableGameComponent
    {
        /// <summary>
        /// Adds a new control to this control manager.
        /// </summary>
        /// <param name="control">The control to add.</param>
        /// <returns>The control that was added.</returns>
        IControl AddControl(IControl control);

        /// <summary>
        /// Removes a control from this control manager.
        /// </summary>
        /// <param name="control">The control to remove.</param>
        void RemoveControl(IControl control);

        /// <summary>
        /// Removes all controls of a specific type from this control manager.
        /// </summary>
        /// <param name="type">The type of control to remove.</param>
        void RemoveAllControls(Type type);

        /// <summary>
        /// Removes all controls matching the supplied predicate function.
        /// </summary>
        /// <param name="func">The predicate function to use.</param>
        void RemoveAllControls(Func<IControl, bool> func);

        /// <summary>
        /// Returns whether this control manager contains the specified control.
        /// </summary>
        /// <param name="control">The control to check.</param>
        /// <returns>True if the specified control exists in this control manager, false otherwise.</returns>
        bool HasControl(IControl control);

        /// <summary>
        /// Returns whether this control manager contains any control of the specified type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>True if this control manager contains a control of the specified type, false otherwise.</returns>
        bool HasControl(Type type);

        /// <summary>
        /// Returns whether this control manager contains any control matching the supplied predicate function.
        /// </summary>
        /// <param name="func">The predicate function.</param>
        /// <returns>True if this control manager contains a control matching the specified predicate, false otherwise.</returns>
        bool HasControl(Func<IControl, bool> func);
    }
}
