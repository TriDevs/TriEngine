/* Primitive.cs
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
using TriDevs.TriEngine2D.Extensions;
using TriDevs.TriEngine2D.Interfaces;

namespace TriDevs.TriEngine2D.Graphics
{
    /// <summary>
    /// Represents a primitive 2D shape composed of triangles.
    /// </summary>
    public abstract class Primitive : IDrawable, IDisposable
    {
        protected uint[] Ids;
        protected uint ColorId;

        protected ushort[] Indices;
        protected float[] Vertices;
        protected int[] Colors;

        /// <summary>
        /// Indices buffer ID assigned to this primitive by GL.BindBuffer.
        /// </summary>
        public uint IndicesID { get { return Ids[0]; } }

        /// <summary>
        /// Vertices buffer ID assigned to this primitive by GL.BindBuffer.
        /// </summary>
        public uint VerticesID { get { return Ids[1]; } }

        /// <summary>
        /// Color buffer ID assigned to this primitive by GL.BindBuffer.
        /// </summary>
        public uint ColorID { get { return ColorId; } }

        protected Primitive(ushort[] indices, Vector3[] vectors, Color[] colors = null)
            : this(indices, vectors.ToFloatArray(), colors)
        {
        }

        protected Primitive(ushort[] indices, float[] vertices, Color[] colors = null)
        {
            if (indices.Length % 3 != 0)
                throw new EngineException(
                    "Primitives can only be composed of a series of triangles. Expected n*3 points, got " +
                    vertices.Length + ".",
                    new ArgumentException("Unexpected number of array items.", "indices"));

            Indices = indices;
            Vertices = vertices;

            Ids = new uint[2];

            GL.GenBuffers(2, Ids);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndicesID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, new IntPtr(Indices.Length * sizeof(ushort)), Indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VerticesID);
            GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(Vertices.Length * sizeof(float)), Vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            if (colors != null)
            {
                Colors = new int[colors.Length];
                for (int i = 0; i < colors.Length; i++)
                    Colors[i] = colors[i].ToColor4().ToArgb();

                GL.GenBuffers(1, out ColorId);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ColorID);
                GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(Colors.Length * sizeof(int)), Colors, BufferUsageHint.StaticDraw);
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }
        }

        public void Draw()
        {
            GL.PushClientAttrib(ClientAttribMask.ClientVertexArrayBit);

            GL.EnableClientState(ArrayCap.VertexArray);

            if (ColorID != 0)
            {
                GL.EnableClientState(ArrayCap.ColorArray);
                GL.BindBuffer(BufferTarget.ArrayBuffer, ColorID);
                GL.ColorPointer(sizeof(int), ColorPointerType.UnsignedByte, 0, 0);
            }

            GL.BindBuffer(BufferTarget.ArrayBuffer, VerticesID);
            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndicesID);
            GL.DrawElements(BeginMode.Triangles, Indices.Length, DrawElementsType.UnsignedShort, 0);
            
            GL.PopClientAttrib();
        }

        public void Dispose()
        {
            GL.DeleteBuffers(2, Ids);

            if (ColorID != 0)
                GL.DeleteBuffers(1, ref ColorId);
        }
    }
}
