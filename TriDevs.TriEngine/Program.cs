﻿/* Program.cs
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
using OpenTK.Graphics.OpenGL;
using TriDevs.TriEngine.Shaders;

namespace TriDevs.TriEngine
{
    /// <summary>
    /// An OpenGL program.
    /// </summary>
    public class Program : IDisposable
    {
        /// <summary>
        /// The ID of this program.
        /// </summary>
        public readonly int ID;

        /// <summary>
        /// Initializes a new <see cref="Program" /> as a shader program.
        /// </summary>
        /// <param name="shaders">The shaders to attach.</param>
        public Program(params Shader[] shaders)
        {
            ID = GL.CreateProgram();

            foreach (var shader in shaders)
            {
                GL.AttachShader(ID, shader.ID);
            }

            GL.LinkProgram(ID);
        }

        public void Dispose()
        {
            GL.DeleteProgram(ID);
        }
    }
}
