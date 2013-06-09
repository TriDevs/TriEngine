/* Font.cs
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
using QuickFont;

namespace TriDevs.TriEngine.Text
{
    /// <summary>
    /// Holds a specific font type.
    /// </summary>
    public class Font
    {
        private const string NameFormat = "{0}@{1}pt";

        private readonly string _name;
        private readonly string _file;
        private readonly int _size;
        private readonly FontType _type;
        private readonly QFont _qfont;

        /// <summary>
        /// Gets the name of this font instance.
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// Gets the file used to create this font instance.
        /// </summary>
        public string File { get { return _file; } }

        /// <summary>
        /// Gets the size of this font in points.
        /// </summary>
        public int Size { get { return _size; } }

        /// <summary>
        /// Gets the font type.
        /// </summary>
        public FontType Type { get { return _type; } }

        /// <summary>
        /// Gets the QFont instance associated with this font.
        /// </summary>
        public QFont QFont { get { return _qfont; } }

        /// <summary>
        /// Gets or sets the color of this font.
        /// </summary>
        public Color Color
        {
            get { return new Color(QFont.Options.Colour); }
            set { QFont.Options.Colour = value.ToColor4(); }
        }

        /// <summary>
        /// Initalizes a new <see cref="Font" /> instance.
        /// </summary>
        /// <param name="name">
        /// Name to use for identifying this font, must be unique.
        /// Can be set to null to allow the constructor to auto-generate a name for the font.
        /// </param>
        /// <param name="file">Path to the font file (TTF or qfont).</param>
        /// <param name="size">Size (in points) to use for this font.</param>
        /// <param name="dropShadow">Whether or not this font should have shadows.</param>
        /// <param name="type">
        /// The type of font. This will be detected by the file extension,
        /// but can be manually specified to control the fallback type used if
        /// one was not detected from the file name
        /// </param>
        public Font(string name, string file, int size, bool dropShadow = false, FontType type = FontType.TTF)
            : this(
                name, file, size, type,
                new FontConstructionConfig(new QFontBuilderConfiguration(dropShadow),
                                           new QFontLoaderConfiguration(dropShadow)))
        {
            
        }

        /// <summary>
        /// Initializes a new <see cref="Font" /> instance using the specified builder configuration.
        /// </summary>
        /// <param name="name">
        /// Name to use for identifying this font, must be unique.
        /// Can be set to null to allow the constructor to auto-generate a name for the font.
        /// </param>
        /// <param name="file">Path to the font file (TTF or qfont).</param>
        /// <param name="size">Size (in points) to use for this font.</param>
        /// <param name="type">
        /// The type of font. This will be detected by the file extension,
        /// but can be manually specified to control the fallback type used if
        /// one was not detected from the file name
        /// </param>
        /// <param name="fontConstructionConfig">The <see cref="FontConstructionConfig" /> containing relevant font build/load configurations.</param>
        public Font(string name, string file, int size, FontType type, FontConstructionConfig fontConstructionConfig)
        {
            _file = file;
            _size = size;

            var ext = Path.GetExtension(_file);

            if (string.IsNullOrEmpty(ext))
                throw new EngineException("Failed to get file extension of font file!",
                                          new IOException("System.IO.Path.GetExtension returned null or empty for specified file."));

            // Disable resharper warning, we are checking for null, resharper doesn't like IsNullOrEmpty
            // ReSharper disable PossibleNullReferenceException
            ext = ext.TrimStart('.').ToLower();
            // ReSharper restore PossibleNullReferenceException

            switch (ext)
            {
                case "ttf":
                    type = FontType.TTF;
                    break;
                case "qfont":
                    type = FontType.QFont;
                    break;
            }

            _type = type;

            QFont font;

            switch (_type)
            {
                case FontType.TTF:
                    if (fontConstructionConfig.BuildConfig == null)
                        throw new EngineException("Builder configuration was null but requested font type requires a builder config!",
                                                  new ArgumentException("BuildConfig was null.", "fontConstructionConfig"));
                    font = new QFont(_file, _size, fontConstructionConfig.BuildConfig);
                    break;
                case FontType.QFont:
                    if (fontConstructionConfig.LoadConfig == null)
                        throw new EngineException("Loader configuration was null but requested font type requires a loader config!",
                                                  new ArgumentException("LoadConfig was null.", "fontConstructionConfig"));
                    font = QFont.FromQFontFile(_file, fontConstructionConfig.LoadConfig);
                    break;
                default:
                    throw new EngineException("Unsupported font type: " + _type,
                                              new ArgumentException("Font type unsupported.", "type"));
            }

            if (font == null)
                throw new EngineException("Font failed to initialize!",
                                          new ArgumentException("Font failed to initialize.", "file"));

            _qfont = font;

            _name = name ?? GetDefaultName(file, size);
        }

        /// <summary>
        /// Returns an auto-generated font name based on the file name and font size.
        /// </summary>
        /// <param name="file">The file name.</param>
        /// <param name="size">The size (in points) of the font.</param>
        /// <returns>The auto-generated font name.</returns>
        public static string GetDefaultName(string file, int size)
        {
            return string.Format(NameFormat, Path.GetFileNameWithoutExtension(file), size);
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Disposes of this font instance,
        /// releasing all unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            QFont.Dispose();
        }
    }
}
