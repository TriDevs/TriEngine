/* Resources.cs
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

using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL;
using QuickFont;
using TriDevs.TriEngine.Shaders;
using TriDevs.TriEngine.Text;

namespace TriDevs.TriEngine
{
    /// <summary>
    /// Static class to manage resources.
    /// </summary>
    public static class Resources
    {
        private static readonly Dictionary<string, Font> Fonts;
        private static readonly Dictionary<string, Shader> Shaders;

        static Resources()
        {
            Fonts = new Dictionary<string, Font>();
            Shaders = new Dictionary<string, Shader>();
        }

        /// <summary>
        /// Base path to the resources directory, relative to the current working directory.
        /// </summary>
        public static string BasePath = "Resources";

        /// <summary>
        /// Path to the fonts directory, relative to <see cref="BasePath" />.
        /// </summary>
        public static string FontPath = "Fonts";

        /// <summary>
        /// Path to the shaders directory, relative to <see cref="BasePath" />.
        /// </summary>
        public static string ShaderPath = "Shaders";

        /// <summary>
        /// Adds a font instance to the resources.
        /// </summary>
        /// <param name="font">The font object to add.</param>
        /// <exception cref="EngineException">Thrown if the resources already contain the specified font.</exception>
        public static void AddFont(Font font)
        {
            if (Fonts.ContainsKey(font.Name))
                throw new EngineException("A font with the specified name has already been added to the resources.");

            Fonts.Add(font.Name, font);
        }

        /// <summary>
        /// Adds a shader instance to the resources.
        /// </summary>
        /// <param name="shader">The shader object to add.</param>
        /// <exception cref="EngineException">Thrown if the resources already contain the specified shader.</exception>
        public static void AddShader(Shader shader)
        {
            if (Shaders.ContainsKey(shader.Name))
                throw new EngineException("A shader with the specified name has already been added to the resources.");

            Shaders.Add(shader.Name, shader);
        }

        /// <summary>
        /// Loads a font file from the default resources path into the resources.
        /// </summary>
        /// <param name="name">Name to assign the font, or null to auto-generate one.</param>
        /// <param name="file">Font file to load.</param>
        /// <param name="size">Size (in points) to use for the font.</param>
        /// <param name="dropShadow">Whether or not the font should have shadows.</param>
        /// <param name="type">The font filetype.</param>
        /// <returns>The newly loaded font object, or existing font object if one with matching name was found.</returns>
        public static Font LoadFont(string name, string file, int size, bool dropShadow = false, FontType type = FontType.TTF)
        {
            return LoadFont(name, file, size, type,
                            new FontConstructionConfig(new QFontBuilderConfiguration(dropShadow),
                                                       new QFontLoaderConfiguration(dropShadow)));
        }

        /// <summary>
        /// Loads a font file from the default resources path into the resources.
        /// </summary>
        /// <param name="name">Name to assign the font, or null to auto-generate one.</param>
        /// <param name="file">Font file to load.</param>
        /// <param name="size">Size (in points) to use for the font.</param>
        /// <param name="type">The font filetype.</param>
        /// <param name="config">The relevant font construction configs.</param>
        /// <returns>The newly loaded font object, or existing font object if one with matching name was found.</returns>
        public static Font LoadFont(string name, string file, int size, FontType type, FontConstructionConfig config)
        {
            var font = GetFont(name);

            if (font != null)
                return font;

            file = Path.Combine(BasePath, FontPath, file);

            font = new Font(name, file, size, type, config);
            AddFont(font);
            return font;
        }

        /// <summary>
        /// Loads a shader file from the default resources path into the resources.
        /// </summary>
        /// <param name="name">Name to assign the shader, or null to auto-generate one.</param>
        /// <param name="file">File to load shader code from.</param>
        /// <param name="type">The type of shader.</param>
        /// <returns>The newly loaded shader object, or existing shader object if one with matching name was found.</returns>
        public static Shader LoadShader(string name, string file, ShaderType type)
        {
            var shader = GetShader(name);

            if (shader != null)
                return shader;

            file = Path.Combine(BasePath, ShaderPath, file);

            shader = new Shader(name, file, type);
            AddShader(shader);
            return shader;
        }

        /// <summary>
        /// Gets the font object with the specified name from the resources,
        /// if it exists.
        /// </summary>
        /// <param name="name">Name of the font object to retrieve.</param>
        /// <returns>The font object with the specified name, if it exists, null otherwise.</returns>
        public static Font GetFont(string name)
        {
            return Fonts.ContainsKey(name) ? Fonts[name] : null;
        }

        /// <summary>
        /// Gets the shader object with the specified name from the resources,
        /// if it exists.
        /// </summary>
        /// <param name="name">Name of the shader object to retrieve.</param>
        /// <returns>The shader object with the specified name, if it exists, null otherwise.</returns>
        public static Shader GetShader(string name)
        {
            return Shaders.ContainsKey(name) ? Shaders[name] : null;
        }
    }
}
