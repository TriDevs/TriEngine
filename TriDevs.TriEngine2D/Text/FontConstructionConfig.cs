/* FontConstructionConfig.cs
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

using QuickFont;

namespace TriDevs.TriEngine2D.Text
{
    /// <summary>
    /// Container class for different QFont configurations for use with the Font constructor.
    /// </summary>
    public class FontConstructionConfig
    {
        /// <summary>
        /// The builder configuration used when constructing fonts
        /// from non-qfont files.
        /// </summary>
        public QFontBuilderConfiguration BuildConfig;
        
        /// <summary>
        /// The loader configuration used when contruscting fonts
        /// from a qfont file.
        /// </summary>
        public QFontLoaderConfiguration LoadConfig;

        /// <summary>
        /// Initialize a new <see cref="FontConstructionConfig" /> with a load configuration.
        /// </summary>
        /// <param name="loadConfig">The <see cref="QFontLoaderConfiguration" /> to use.</param>
        public FontConstructionConfig(QFontLoaderConfiguration loadConfig)
            : this(null, loadConfig)
        {
            
        }

        /// <summary>
        /// Initializes a new <see cref="FontConstructionConfig" /> with a builder configuration
        /// and optional loader configuration.
        /// </summary>
        /// <param name="buildConfig">The builder configuration to use.</param>
        /// <param name="loadConfig">Optional loader configuration to set.</param>
        public FontConstructionConfig(QFontBuilderConfiguration buildConfig, QFontLoaderConfiguration loadConfig = null)
        {
            BuildConfig = buildConfig;
            LoadConfig = loadConfig;
        }
    }
}
