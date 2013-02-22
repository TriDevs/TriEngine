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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using QuickFont;

namespace TriDevs.TriEngine2D.Text
{
    public class Font
    {
        private readonly QFont _qfont;

        public QFont QFont { get { return _qfont; } }

        public Font(string file, int size, bool dropShadow = false, FontType type = FontType.TTF)
        {
            var ext = Path.GetExtension(file);

            if (string.IsNullOrEmpty(ext))
                Helpers.Exceptions.Throw("Failed to get file extension of font file!");

            ext = ext.TrimStart('.').ToLower();

            switch (ext)
            {
                case "ttf":
                    type = FontType.TTF;
                    break;
                case "qfont":
                    type = FontType.QFont;
                    break;
                default:
                    type = FontType.Unsupported;
                    break;
            }

            QFont font = null;

            switch (type)
            {
                case FontType.TTF:
                    font = new QFont(file, size, new QFontBuilderConfiguration(dropShadow));
                    break;
                case FontType.QFont:
                    font = QFont.FromQFontFile(file, new QFontLoaderConfiguration(dropShadow));
                    break;
                default:
                    Helpers.Exceptions.Throw("Unsupported font type: " + type);
                    break;
            }

            if (font == null)
                Helpers.Exceptions.Throw("Font not initialized!");

            _qfont = font;
        }
    }
}
