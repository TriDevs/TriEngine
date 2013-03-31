/* Triangle.cs
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
using OpenTK.Graphics.OpenGL;
using TriDevs.TriEngine2D.Interfaces;

namespace TriDevs.TriEngine2D.Graphics
{
    public class Triangle : IDrawable, IDisposable
    {
        private int _id;
        private Vector3[] _vertices;

        public int ID { get { return _id; } }

        public Triangle(Point<int> top, Point<int> left, Point<int> right)
        {
            _vertices = new[]
            {
                new Vector3(top.X, top.Y, 0),
                new Vector3(left.X, left.Y, 0),
                new Vector3(right.X, right.Y, 0)
            };

            GL.GenBuffers(1, out _id);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _id);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(_vertices.Length * Vector3.SizeInBytes), _vertices, BufferUsageHint.StaticDraw);
        }

        public void Draw()
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.VertexAttribPointer(0, _vertices.Length, VertexAttribPointerType.Float, false, 0, 0);
            GL.DrawArrays(BeginMode.Triangles, 0, _vertices.Length);
            GL.DisableVertexAttribArray(0);
            GL.DisableClientState(ArrayCap.VertexArray);
        }

        public void Dispose()
        {
            GL.DeleteBuffers(1, ref _id);
        }
    }
}
