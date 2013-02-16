/* GameState.cs
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
using System.Linq;
using TriDevs.TriEngine2D.Interfaces;

namespace TriDevs.TriEngine2D.StateManagement
{
    /// <summary>
    /// Base GameState class that all other game states derive from,
    /// defines basic GameState behaviour.
    /// </summary>
    public abstract class GameState : IGameState
    {
        protected readonly List<IGameComponent> Components;

        public bool Enabled { get; set; }

        public bool Paused { get; set; }

        protected GameState()
        {
            Components = new List<IGameComponent>();
        }

        public virtual void Enable()
        {
            Enabled = true;
        }

        public virtual void Disable()
        {
            Enabled = false;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            
        }

        public virtual void Load()
        {
            
        }

        public virtual void Unload()
        {
            
        }

        public virtual void Pause()
        {
            Paused = true;
        }

        public virtual void Unpause()
        {
            Paused = false;
        }

        public IGameComponent AddComponent(IGameComponent component)
        {
            if (HasComponent(component))
                throw new InvalidOperationException("Cannot add the same component more than once.");
            
            Components.Add(component);
            component.Enable();
            return component; // var comp = someState.AddComponent(new SomeComponent());
        }

        public void RemoveComponent(IGameComponent component)
        {
            var match = Components.FirstOrDefault(c => c == component);
            if (match == null)
                return;

            Components.Remove(match);
            match.Disable();
        }

        public void RemoveAllComponents()
        {
            Components.ForEach(c => c.Disable());
            Components.Clear();
        }

        public void RemoveAllComponents(Type type)
        {
            RemoveAllComponents(c => c.GetType() == type);
        }

        public void RemoveAllComponents(Predicate<IGameComponent> predicate)
        {
            var removed = Components.FindAll(predicate);
            if (removed.Count < 1)
                return;

            Components.RemoveAll(predicate);
            removed.ForEach(c => c.Disable());
        }

        public bool HasComponent(IGameComponent component)
        {
            return Components.Contains(component);
        }

        public bool HasComponent(Type type)
        {
            return Components.Any(c => c.GetType() == type);
        }

        public bool HasComponent(Func<IGameComponent, bool> func)
        {
            return Components.Any(func);
        }

        public IEnumerable<IGameComponent> GetAllComponents()
        {
            return Components.AsReadOnly();
        }

        public IGameComponent GetComponent(Type type)
        {
            return Components.FirstOrDefault(c => c.GetType() == type);
        }

        public IEnumerable<IGameComponent> GetAllComponents(Type type)
        {
            return Components.FindAll(c => c.GetType() == type);
        }

        public IGameComponent GetComponent(Func<IGameComponent, bool> func)
        {
            return Components.FirstOrDefault(func);
        }

        public IEnumerable<IGameComponent> GetAllComponents(Func<IGameComponent, bool> func)
        {
            return Components.Where(func);
        }
    }
}
