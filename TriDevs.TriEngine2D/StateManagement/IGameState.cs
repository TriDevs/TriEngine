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

using System;
using System.Collections.Generic;
using TriDevs.TriEngine.Interfaces;

namespace TriDevs.TriEngine.StateManagement
{
    /// <summary>
    /// A game state that can be used with the game state manager.
    /// Represent a specific state of the game, like main menu and options screen.
    /// </summary>
    public interface IGameState : IDrawable, IUpdatable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this game state is currently paused.
        /// </summary>
        bool Paused { get; set; }

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
        /// <returns>The component that was added.</returns>
        IGameComponent AddComponent(IGameComponent component);

        /// <summary>
        /// Removes the specified component from this game state.
        /// </summary>
        /// <param name="component"></param>
        void RemoveComponent(IGameComponent component);

        /// <summary>
        /// Removes all components from the game state.
        /// </summary>
        void RemoveAllComponents();

        /// <summary>
        /// Removes all components of the specified type from the game state.
        /// </summary>
        /// <param name="type">The type of component to remove.</param>
        void RemoveAllComponents(Type type);

        /// <summary>
        /// Removes all components that match the supplied predicate function.
        /// </summary>
        /// <param name="predicate">The predicate function.</param>
        void RemoveAllComponents(Predicate<IGameComponent> predicate);

        /// <summary>
        /// Returns whether this game state contains the specified <see cref="IGameComponent" />.
        /// </summary>
        /// <param name="component">The component to check for.</param>
        /// <returns>True if the component has been added to this game state, false otherwise.</returns>
        bool HasComponent(IGameComponent component);

        /// <summary>
        /// Returns whether this game state contains a specific type of component.
        /// </summary>
        /// <param name="type">The type to check for.</param>
        /// <returns>True if the type of component has been added to this game state, false otherwise.</returns>
        bool HasComponent(Type type);

        /// <summary>
        /// Returns whether this game state contains a component that matches the supplied predicate.
        /// </summary>
        /// <param name="func">Predicate function to use for search.</param>
        /// <returns>True if the game state contains a matching component, false otherwise.</returns>
        bool HasComponent(Func<IGameComponent, bool> func);

        /// <summary>
        /// Returns a read-only collection of all components in this game state.
        /// </summary>
        /// <returns>Read-only collection of components.</returns>
        IEnumerable<IGameComponent> GetAllComponents();

        /// <summary>
        /// Returns the specified component type if it exists in this game state.
        /// </summary>
        /// <param name="type">The component type to get.</param>
        /// <returns>The component object, or null if it's not added to this game state.</returns>
        IGameComponent GetComponent(Type type);

        /// <summary>
        /// Returns all components of the specified type.
        /// </summary>
        /// <param name="type">The type of game component requested.</param>
        /// <returns>A collection of all components of matching type.</returns>
        IEnumerable<IGameComponent> GetAllComponents(Type type);

        /// <summary>
        /// Returns the first component that matches the supplied predicate function.
        /// </summary>
        /// <param name="func">The predicate function.</param>
        /// <returns>Component that matches the predicate, null if no matches were found.</returns>
        IGameComponent GetComponent(Func<IGameComponent, bool> func);

        /// <summary>
        /// Returns all components that matches the supplied predicate function.
        /// </summary>
        /// <param name="func">The predicate function.</param>
        /// <returns>Collection of all matching components, empty collection if no matches were found.</returns>
        IEnumerable<IGameComponent> GetAllComponents(Func<IGameComponent, bool> func);
    }
}
