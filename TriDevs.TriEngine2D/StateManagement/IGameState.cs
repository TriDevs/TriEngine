/* IGameState.cs
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
    /// A game state that can be used with the game state manager.
    /// Represent a specific state of the game, like main menu and options screen.
    /// </summary>
    public interface IGameState : IDrawableGameComponent
    {
        /// <summary>
        /// Loads resources associated with this game component.
        /// </summary>
        void Load();

        /// <summary>
        /// Unloads resources that were loaded in the <see cref="Load" /> method.
        /// </summary>
        void Unload();

        /// <summary>
        /// Pauses the game state,
        /// preventing update calls from running.
        /// </summary>
        void Pause();

        /// <summary>
        /// Unpauses the game state,
        /// enabling update calls again.
        /// </summary>
        void Unpause();

        /// <summary>
        /// Adds a game component to this game state.
        /// </summary>
        /// <param name="component">The component to add.</param>
        void AddComponent(IGameComponent component);

        /// <summary>
        /// Removes a specific game component from this game state.
        /// </summary>
        /// <param name="component">The component to remove.</param>
        void RemoveComponent(IGameComponent component);
    }
}
