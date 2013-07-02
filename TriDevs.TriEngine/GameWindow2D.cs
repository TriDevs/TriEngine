/* GameWindow2D.cs
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
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TriDevs.TriEngine
{
    /// <summary>
    /// Game window class specialized for drawing 2D graphics.
    /// </summary>
    public abstract class GameWindow2D : GameWindow
    {
        private Color _clearColor;

        /// <summary>
        /// Gets or sets the clear color for this window.
        /// </summary>
        protected Color ClearColor
        {
            get { return _clearColor; }
            set
            {
                _clearColor = value;
                GL.ClearColor(_clearColor.ToColor4());
            }
        }

        protected GameWindow2D(int width, int height, string title, bool vsync = true)
            : base(width, height, GraphicsMode.Default, title)
        {
            VSync = vsync ? VSyncMode.On : VSyncMode.Off;

            ClearColor = Color.CornflowerBlue;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, ClientRectangle.Width, ClientRectangle.Height);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadIdentity();

            GL.Ortho(0, ClientRectangle.Width - 1, ClientRectangle.Height - 1, 0, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Initialize();
        }

        protected sealed override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            OnDraw(e);

            SwapBuffers();
        }

        protected abstract void OnDraw(FrameEventArgs e);

        protected void Initialize()
        {
            try
            {
                GL.Viewport(0, 0, ClientRectangle.Width, ClientRectangle.Height);

                GL.MatrixMode(MatrixMode.Projection);

                GL.LoadIdentity();

                GL.Ortho(0, ClientRectangle.Width - 1, ClientRectangle.Height - 1, 0, -1, 1);

                GL.MatrixMode(MatrixMode.Modelview);

                // Disable the Z-buffer, this is a 2D game window
                //GL.Disable(EnableCap.DepthTest);
                //GL.Disable(EnableCap.CullFace);
                GL.Enable(EnableCap.Blend);
                GL.BlendEquation(BlendEquationMode.FuncAdd);
                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                //GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
                //GL.RenderMode(RenderingMode.Render);

                GL.ClearColor(ClearColor.ToColor4());
            }
            catch (Exception ex)
            {
                Helpers.Exceptions.Throw(ex, "Initialization of 2D game window failed during OpenGL setup!");
            }
        }
    }
}
