/* IGameStateManager.cs
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

using TriDevs.TriEngine2D.Interfaces;

namespace TriDevs.TriEngine2D.StateManagement
{
    /// <summary>
    /// Game state manager that keeps track of the active game states and provides
    /// methods to control the states.
    /// </summary>
    public interface IGameStateManager : IDrawableGameComponent
    {
        /// <summary>
        /// Gets the number of game states currently in the stack.
        /// </summary>
        int StateCount { get; }

        /// <summary>
        /// Gets the currently active game state.
        /// </summary>
        IGameState ActiveState { get; }

        /// <summary>
        /// Pushes a new game state onto the stack, pausing the current one.
        /// </summary>
        /// <param name="state">The new game state to push onto the stack.</param>
        /// <returns>The game state that was pushed.</returns>
        IGameState Push(IGameState state);

        /// <summary>
        /// Pops the currently active state from the stack, unpausing the previous one.
        /// </summary>
        /// <returns>The state that was popped.</returns>
        IGameState Pop();

        /// <summary>
        /// Returns the game state at the top of the stack, without popping it.
        /// </summary>
        /// <returns>The state at the top of the stack.</returns>
        IGameState Peek();

        /// <summary>
        /// Switches to a new game state, discarding all previous ones in the stack.
        /// </summary>
        /// <param name="state">The new state to switch to.</param>
        /// <returns>The state that was switched to.</returns>
        IGameState Switch(IGameState state);
    }
}
