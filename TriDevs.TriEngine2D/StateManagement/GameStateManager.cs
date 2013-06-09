/* GameStateManager.cs
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

namespace TriDevs.TriEngine.StateManagement
{
    /// <summary>
    /// Game state manager that keeps track of the active game states and provides
    /// methods to control the states.
    /// </summary>
    public class GameStateManager : IGameStateManager
    {
        // This is where we store the active states
        // When we push a new state on the stack, the previous is "paused",
        // when the pushed state is popped, we "unpause" the previous state.
        private Stack<IGameState> _states;

        public int StateCount { get { return _states.Count; } }

        // Store the active state instead of doing a Peek() on the stack
        // every time, to save performance.
        public IGameState ActiveState { get; private set; }

        // TODO: Remove parameter-less constructor
        // and force a game state to be supplied?
        /// <summary>
        /// Creates a new <see cref="GameStateManager" /> with an empty state stack.
        /// </summary>
        public GameStateManager()
        {
            _states = new Stack<IGameState>();
        }

        /// <summary>
        /// Creates a new <see cref="GameStateManager" />
        /// and pushes an initial state onto the stack.
        /// </summary>
        /// <param name="state">The state to initialize with.</param>
        public GameStateManager(IGameState state) : this()
        {
            Push(state);
        }

        public void Update()
        {
            if (ActiveState != null)
                ActiveState.Update();
        }

        public void Draw()
        {
            if (ActiveState != null)
                ActiveState.Draw();
        }

        public IGameState Push(IGameState state)
        {
            if (ActiveState != null)
                ActiveState.Pause();

            state.Load();
            _states.Push(state);
            ActiveState = state;
            return state;
        }

        public IGameState Pop()
        {
            if (_states.Count == 1)
                throw new InvalidOperationException("Cannot pop the last remaining game state from stack.");

            var state = _states.Pop();
            state.Unload();
            ActiveState = _states.Peek();
            ActiveState.Unpause();
            return state;
        }

        public IGameState Peek()
        {
            return _states.Peek();
        }

        public IGameState Switch(IGameState state)
        {
            while (_states.Count > 0)
                _states.Pop().Unload();

            _states = new Stack<IGameState>();
            return Push(state);
        }
    }
}
