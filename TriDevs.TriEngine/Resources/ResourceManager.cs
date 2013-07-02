/* ResourceManager.cs
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
using System.Linq;
using OpenTK.Graphics.OpenGL;
using QuickFont;
using TriDevs.TriEngine.Audio;
using TriDevs.TriEngine.Shaders;
using TriDevs.TriEngine.Text;

namespace TriDevs.TriEngine.Resources
{
    /// <summary>
    /// Static class to manage resources.
    /// </summary>
    public static class ResourceManager
    {
        private static readonly Dictionary<string, IResource> Resources; 

        static ResourceManager()
        {
            Resources = new Dictionary<string, IResource>();
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
        /// Path to the sounds directory, relative to <see cref="BasePath" />.
        /// </summary>
        public static string SoundPath = "Sounds";

        /// <summary>
        /// Path to the songs directory, relative to <see cref="BasePath" />.
        /// </summary>
        public static string SongPath = "Songs";

        #region Font Methods

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
            if (Has<Font>(name))
                return Get<Font>(name);

            file = Path.Combine(BasePath, FontPath, file);

            var font = new Font(name, file, size, type, config);
            Add(font);
            return font;
        }

        #endregion Font Methods

        #region Shader Methods

        /// <summary>
        /// Loads a shader file from the default resources path into the resources.
        /// </summary>
        /// <param name="name">Name to assign the shader, or null to auto-generate one.</param>
        /// <param name="file">File to load shader code from.</param>
        /// <param name="type">The type of shader.</param>
        /// <returns>The newly loaded shader object, or existing shader object if one with matching name was found.</returns>
        public static Shader LoadShader(string name, string file, ShaderType type)
        {
            if (Has<Shader>(name))
                return Get<Shader>(name);

            file = Path.Combine(BasePath, ShaderPath, file);

            var shader = new Shader(name, file, type);
            Add(shader);
            return shader;
        }

        #endregion Shader Methods

        #region Sound Methods

        /// <summary>
        /// Loads a sound file from the default resources path into the resources.
        /// </summary>
        /// <param name="name">Name to assign the sound.</param>
        /// <param name="file">File to load sound from.</param>
        /// <param name="format">The audio format of the sound.</param>
        /// <returns>The newly loaded sound object, or existing sound object if one with matching name was found.</returns>
        public static ISound LoadSound(string name, string file, AudioFormat format = AudioFormat.Wav)
        {
            if (Has<ISound>(name))
                return Get<ISound>(name);

            file = Path.Combine(BasePath, SoundPath, file);

            var sound = new Sound(name, file, format);
            Add(sound);
            return sound;
        }

        #endregion Sound Methods

        #region Song Methods

        /// <summary>
        /// Loads a song file from the default resources path into the resources.
        /// </summary>
        /// <param name="name">Name to assign the song.</param>
        /// <param name="file">File to load song from.</param>
        /// <param name="format">The audio format of the song.</param>
        /// <returns>The newly loaded song object, or existing song object if one with matching name was found.</returns>
        public static ISong LoadSong(string name, string file, AudioFormat format = AudioFormat.Ogg)
        {
            if (Has<ISong>(name))
                return Get<ISong>(name);

            file = Path.Combine(BasePath, SongPath, file);

            var song = new Song(name, file, format);
            Add(song);
            return song;
        }

        #endregion Song Methods

        #region Generic Methods

        /// <summary>
        /// Checks if the resource with the specified name has been added to the resource collection.
        /// </summary>
        /// <param name="name">Name to search for.</param>
        /// <returns>True if the resource has been added, false otherwise.</returns>
        public static bool Has(string name)
        {
            return Resources.ContainsKey(name);
        }

        /// <summary>
        /// Checks if the resource with the specified name and type has been added to the resource collection.
        /// </summary>
        /// <typeparam name="T">Type of resource to search for.</typeparam>
        /// <param name="name">Name to search for.</param>
        /// <returns>True if the resource has been added, false otherwise.</returns>
        public static bool Has<T>(string name) where T : class, IResource
        {
            return Has(name) && Resources[name].GetType() == typeof (T);
        }

        /// <summary>
        /// Gets the resource with the specified name.
        /// </summary>
        /// <param name="name">Name of resource to get.</param>
        /// <exception cref="ResourceException">Thrown if the resource does not exist.</exception>
        /// <returns>The <see cref="IResource" /> object with the specified name.</returns>
        public static IResource Get(string name)
        {
            if (!Has(name))
                throw new ResourceException("Attempted to get non-existing resource \"" + name + "\"!");

            return Resources[name];
        }

        /// <summary>
        /// Gets the resource with the specified name and casts it to the specified type.
        /// </summary>
        /// <typeparam name="T">Type to cast to.</typeparam>
        /// <param name="name">Name of resource to get.</param>
        /// <exception cref="ResourceException">Thrown if the resource could not be found
        /// or if the cast failed.</exception>
        /// <returns>The resource object of type T with the specified name.</returns>
        public static T Get<T>(string name) where T : class, IResource
        {
            if (!Has(name))
                throw new ResourceException("Attempted to get non-existing resource \"" + name + "\"!");

            T resource = Get(name) as T;

            if (resource == null)
                throw new ResourceException("Resource with name \"" + name +
                                            "\" is not of the requested type: " + typeof (T));

            return resource;
        }

        /// <summary>
        /// Gets all resources of the specified type.
        /// </summary>
        /// <typeparam name="T">Type of resource to get.</typeparam>
        /// <returns>An IEnumerable containing the relevant resources.</returns>
        /// <remarks>Returned collection will be empty if no matching resources were found.</remarks>
        public static IEnumerable<T> GetAll<T>() where T : class, IResource
        {
            return Resources.Values.Where(r => r is T).Cast<T>();
        }

        /// <summary>
        /// Adds a resource to the resource collection.
        /// </summary>
        /// <param name="resource">Resource to add.</param>
        /// <exception cref="ResourceException">Thrown if the collection already contains a resource
        /// with the same name.</exception>
        public static void Add(IResource resource)
        {
            if (Has(resource.Name))
                throw new ResourceException("Attempted to add resource that already exists: " + resource.Name);

            Resources.Add(resource.Name, resource);
        }

        #endregion Generic Methods
    }
}
