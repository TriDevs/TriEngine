/* ControlManager.cs
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

namespace TriDevs.TriEngine2D.UI
{
    /// <summary>
    /// Control manager to manage various UI controls for a game.
    /// </summary>
    public class ControlManager : IControlManager
    {
        private readonly List<IControl> _controls;

        private bool _enabled;

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                _controls.ForEach(c => c.Enabled = _enabled);
            }
        }

        /// <summary>
        /// Initializes a new instance of this control manager.
        /// </summary>
        public ControlManager()
        {
            _controls = new List<IControl>();
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            _controls.ForEach(c => c.Draw());
        }

        public IControl AddControl(IControl control)
        {
            if (HasControl(control))
                throw new InvalidOperationException("Cannot add a control more than once.");
            control.Enable();
            _controls.Add(control);
            control.Show();
            return control;
        }

        public void RemoveControl(IControl control)
        {
            if (!HasControl(control))
                return;
            var match = _controls.FirstOrDefault(c => c == control);
            if (match == null)
                return;
            match.Hide();
            match.Disable();
            _controls.Remove(match);
        }

        public void RemoveAllControls(Type type)
        {
            RemoveAllControls(c => c.GetType() == type);
        }

        public void RemoveAllControls(Func<IControl, bool> func)
        {
            var toRemove = _controls.Where(func);
            var controls = toRemove as IList<IControl> ?? toRemove.ToList();
            if (controls.Count < 0)
                return;
            controls.ToList().ForEach(c =>
            {
                c.Hide();
                c.Disable();
            });
            _controls.RemoveAll(c => func(c));
        }

        public bool HasControl(IControl control)
        {
            return HasControl(c => c == control);
        }

        public bool HasControl(Type type)
        {
            return HasControl(c => c.GetType() == type);
        }

        public bool HasControl(Func<IControl, bool> func)
        {
            return _controls.Any(func);
        }
    }
}
