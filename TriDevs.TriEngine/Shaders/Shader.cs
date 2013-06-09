/* Shader.cs
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
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace TriDevs.TriEngine.Shaders
{
    /// <summary>
    /// GLSL shader object loaded and compiled from a *.glsl shader file.
    /// </summary>
    public class Shader : IDisposable
    {
        private readonly string _name;
        private readonly string _file;

        /// <summary>
        /// The name of this shader object.
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// The file containing the source for this shader.
        /// </summary>
        public string File { get { return _file; } }

        /// <summary>
        /// ID of the shader compiled by OpenGL.
        /// </summary>
        public readonly int ID;

        /// <summary>
        /// Creates a new shader from specified GLSL source file.
        /// </summary>
        /// <param name="name">
        /// The name to give to this shader,
        /// or null to let constructor auto-generate a name based on the file name.
        /// </param>
        /// <param name="file">GLSL source to use.</param>
        /// <param name="type">The type of shader to create.</param>
        public Shader(string name, string file, ShaderType type)
        {
            _file = file;
            _name = name ?? GetDefaultName(_file);
            ID = GL.CreateShader(type);
            var source = System.IO.File.ReadAllText(_file);
            GL.ShaderSource(ID, source);
            GL.CompileShader(ID);
        }

        /// <summary>
        /// Returns an auto-generated shader name based on the file name.
        /// </summary>
        /// <param name="file">The file name.</param>
        /// <returns>The auto-generated shader name.</returns>
        public static string GetDefaultName(string file)
        {
            return Path.GetFileNameWithoutExtension(file);
        }

        public void Dispose()
        {
            GL.DeleteShader(ID);
        }
    }
}
