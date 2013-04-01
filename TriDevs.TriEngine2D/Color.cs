/* Color.cs
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

using System.Diagnostics.Contracts;
using OpenTK;
using OpenTK.Graphics;

namespace TriDevs.TriEngine2D
{
    /// <summary>
    /// Represents an RGBA color that can be used with TriEngine2D.
    /// </summary>
    public struct Color
    {
        #region Static pre-defined Colors

        // Define *some* static colors that we can use.
        // 142 pre-defined colors

        /// <summary>
        /// The color AliceBlue.
        /// </summary>
        public static readonly Color AliceBlue = new Color(240, 248, 255);

        /// <summary>
        /// The color AntiqueWhite.
        /// </summary>
        public static readonly Color AntiqueWhite = new Color(250, 235, 215);

        /// <summary>
        /// The color Aqua.
        /// </summary>
        public static readonly Color Aqua = new Color(0, 255, 255);

        /// <summary>
        /// The color Aquamarine.
        /// </summary>
        public static readonly Color Aquamarine = new Color(127, 255, 212);

        /// <summary>
        /// The color Azure.
        /// </summary>
        public static readonly Color Azure = new Color(240, 255, 255);

        /// <summary>
        /// The color Beige.
        /// </summary>
        public static readonly Color Beige = new Color(245, 245, 220);

        /// <summary>
        /// The color Bisque.
        /// </summary>
        public static readonly Color Bisque = new Color(255, 228, 196);

        /// <summary>
        /// The color Black.
        /// </summary>
        public static readonly Color Black = new Color(0, 0, 0);

        /// <summary>
        /// The color BlanchedAlmond.
        /// </summary>
        public static readonly Color BlanchedAlmond = new Color(255, 235, 205);

        /// <summary>
        /// The color Blue.
        /// </summary>
        public static readonly Color Blue = new Color(0, 0, 255);

        /// <summary>
        /// The color BlueViolet.
        /// </summary>
        public static readonly Color BlueViolet = new Color(138, 43, 226);

        /// <summary>
        /// The color Brown.
        /// </summary>
        public static readonly Color Brown = new Color(165, 42, 42);

        /// <summary>
        /// The color BurlyWood.
        /// </summary>
        public static readonly Color BurlyWood = new Color(222, 184, 135);

        /// <summary>
        /// The color CadetBlue.
        /// </summary>
        public static readonly Color CadetBlue = new Color(95, 158, 160);

        /// <summary>
        /// The color Chartreuse.
        /// </summary>
        public static readonly Color Chartreuse = new Color(127, 255, 0);

        /// <summary>
        /// The color Chocolate.
        /// </summary>
        public static readonly Color Chocolate = new Color(210, 105, 30);

        /// <summary>
        /// The color Coral.
        /// </summary>
        public static readonly Color Coral = new Color(255, 127, 80);

        /// <summary>
        /// The color CornflowerBlue.
        /// </summary>
        public static readonly Color CornflowerBlue = new Color(100, 149, 237);

        /// <summary>
        /// The color Cornsilk.
        /// </summary>
        public static readonly Color Cornsilk = new Color(255, 248, 220);

        /// <summary>
        /// The color Crimson.
        /// </summary>
        public static readonly Color Crimson = new Color(220, 20, 60);

        /// <summary>
        /// The color Cyan.
        /// </summary>
        public static readonly Color Cyan = new Color(0, 255, 255);

        /// <summary>
        /// The color DarkBlue.
        /// </summary>
        public static readonly Color DarkBlue = new Color(0, 0, 139);

        /// <summary>
        /// The color DarkCyan.
        /// </summary>
        public static readonly Color DarkCyan = new Color(0, 139, 139);

        /// <summary>
        /// The color DarkGoldenrod.
        /// </summary>
        public static readonly Color DarkGoldenrod = new Color(184, 134, 11);

        /// <summary>
        /// The color DarkGray.
        /// </summary>
        public static readonly Color DarkGray = new Color(169, 169, 169);

        /// <summary>
        /// The color DarkGreen.
        /// </summary>
        public static readonly Color DarkGreen = new Color(0, 100, 0);

        /// <summary>
        /// The color DarkKhaki.
        /// </summary>
        public static readonly Color DarkKhaki = new Color(189, 183, 107);

        /// <summary>
        /// The color DarkMagenta.
        /// </summary>
        public static readonly Color DarkMagenta = new Color(139, 0, 139);

        /// <summary>
        /// The color DarkOliveGreen.
        /// </summary>
        public static readonly Color DarkOliveGreen = new Color(85, 107, 47);

        /// <summary>
        /// The color DarkOrange.
        /// </summary>
        public static readonly Color DarkOrange = new Color(255, 140, 0);

        /// <summary>
        /// The color DarkOrchid.
        /// </summary>
        public static readonly Color DarkOrchid = new Color(153, 50, 204);

        /// <summary>
        /// The color DarkRed.
        /// </summary>
        public static readonly Color DarkRed = new Color(139, 0, 0);

        /// <summary>
        /// The color DarkSalmon.
        /// </summary>
        public static readonly Color DarkSalmon = new Color(233, 150, 122);

        /// <summary>
        /// The color DarkSeaGreen.
        /// </summary>
        public static readonly Color DarkSeaGreen = new Color(143, 188, 139);

        /// <summary>
        /// The color DarkSlateBlue.
        /// </summary>
        public static readonly Color DarkSlateBlue = new Color(72, 61, 139);

        /// <summary>
        /// The color DarkSlateGray.
        /// </summary>
        public static readonly Color DarkSlateGray = new Color(47, 79, 79);

        /// <summary>
        /// The color DarkTurquoise.
        /// </summary>
        public static readonly Color DarkTurquoise = new Color(0, 206, 209);

        /// <summary>
        /// The color DarkViolet.
        /// </summary>
        public static readonly Color DarkViolet = new Color(148, 0, 211);

        /// <summary>
        /// The color DeepPink.
        /// </summary>
        public static readonly Color DeepPink = new Color(255, 20, 147);

        /// <summary>
        /// The color DeepSkyBlue.
        /// </summary>
        public static readonly Color DeepSkyBlue = new Color(0, 191, 255);

        /// <summary>
        /// The color DimGray.
        /// </summary>
        public static readonly Color DimGray = new Color(105, 105, 105);

        /// <summary>
        /// The color DodgerBlue.
        /// </summary>
        public static readonly Color DodgerBlue = new Color(30, 144, 255);

        /// <summary>
        /// The color Firebrick.
        /// </summary>
        public static readonly Color Firebrick = new Color(178, 34, 34);

        /// <summary>
        /// The color FloralWhite.
        /// </summary>
        public static readonly Color FloralWhite = new Color(255, 250, 240);

        /// <summary>
        /// The color ForestGreen.
        /// </summary>
        public static readonly Color ForestGreen = new Color(34, 139, 34);

        /// <summary>
        /// The color Fuchsia.
        /// </summary>
        public static readonly Color Fuchsia = new Color(255, 0, 255);

        /// <summary>
        /// The color Gainsboro.
        /// </summary>
        public static readonly Color Gainsboro = new Color(220, 220, 220);

        /// <summary>
        /// The color GhostWhite.
        /// </summary>
        public static readonly Color GhostWhite = new Color(248, 248, 255);

        /// <summary>
        /// The color Gold.
        /// </summary>
        public static readonly Color Gold = new Color(255, 215, 0);

        /// <summary>
        /// The color Goldenrod.
        /// </summary>
        public static readonly Color Goldenrod = new Color(218, 165, 32);

        /// <summary>
        /// The color Gray.
        /// </summary>
        public static readonly Color Gray = new Color(128, 128, 128);

        /// <summary>
        /// The color Green.
        /// </summary>
        public static readonly Color Green = new Color(0, 128, 0);

        /// <summary>
        /// The color GreenYellow.
        /// </summary>
        public static readonly Color GreenYellow = new Color(173, 255, 47);

        /// <summary>
        /// The color HoneyDew.
        /// </summary>
        public static readonly Color HoneyDew = new Color(240, 255, 240);

        /// <summary>
        /// The color HotPink.
        /// </summary>
        public static readonly Color HotPink = new Color(255, 105, 180);

        /// <summary>
        /// The color IndianRed.
        /// </summary>
        public static readonly Color IndianRed = new Color(205, 92, 92);

        /// <summary>
        /// The color Indigo.
        /// </summary>
        public static readonly Color Indigo = new Color(75, 0, 130);

        /// <summary>
        /// The color Ivory.
        /// </summary>
        public static readonly Color Ivory = new Color(255, 255, 240);

        /// <summary>
        /// The color Khaki.
        /// </summary>
        public static readonly Color Khaki = new Color(240, 230, 140);

        /// <summary>
        /// The color Lavender.
        /// </summary>
        public static readonly Color Lavender = new Color(230, 230, 250);

        /// <summary>
        /// The color LavenderBlush.
        /// </summary>
        public static readonly Color LavenderBlush = new Color(255, 240, 245);

        /// <summary>
        /// The color LawnGreen.
        /// </summary>
        public static readonly Color LawnGreen = new Color(124, 252, 0);

        /// <summary>
        /// The color LemonChiffon.
        /// </summary>
        public static readonly Color LemonChiffon = new Color(255, 250, 205);

        /// <summary>
        /// The color LightBlue.
        /// </summary>
        public static readonly Color LightBlue = new Color(173, 216, 230);

        /// <summary>
        /// The color LightCoral.
        /// </summary>
        public static readonly Color LightCoral = new Color(240, 128, 128);

        /// <summary>
        /// The color LightCyan.
        /// </summary>
        public static readonly Color LightCyan = new Color(224, 255, 255);

        /// <summary>
        /// The color LightGoldenrodYellow.
        /// </summary>
        public static readonly Color LightGoldenrodYellow = new Color(250, 250, 210);

        /// <summary>
        /// The color LightGray.
        /// </summary>
        public static readonly Color LightGray = new Color(211, 211, 211);

        /// <summary>
        /// The color LightGreen.
        /// </summary>
        public static readonly Color LightGreen = new Color(144, 238, 144);

        /// <summary>
        /// The color LightPink.
        /// </summary>
        public static readonly Color LightPink = new Color(255, 182, 193);

        /// <summary>
        /// The color LightSalmon.
        /// </summary>
        public static readonly Color LightSalmon = new Color(255, 160, 122);

        /// <summary>
        /// The color LightSeaGreen.
        /// </summary>
        public static readonly Color LightSeaGreen = new Color(32, 178, 170);

        /// <summary>
        /// The color LightSkyBlue.
        /// </summary>
        public static readonly Color LightSkyBlue = new Color(135, 206, 250);

        /// <summary>
        /// The color LightSlateGray.
        /// </summary>
        public static readonly Color LightSlateGray = new Color(119, 136, 153);

        /// <summary>
        /// The color LightSteelBlue.
        /// </summary>
        public static readonly Color LightSteelBlue = new Color(176, 196, 222);

        /// <summary>
        /// The color LightYellow.
        /// </summary>
        public static readonly Color LightYellow = new Color(255, 255, 224);

        /// <summary>
        /// The color Lime.
        /// </summary>
        public static readonly Color Lime = new Color(0, 255, 0);

        /// <summary>
        /// The color LimeGreen.
        /// </summary>
        public static readonly Color LimeGreen = new Color(50, 205, 50);

        /// <summary>
        /// The color Linen.
        /// </summary>
        public static readonly Color Linen = new Color(250, 240, 230);

        /// <summary>
        /// The color Magenta.
        /// </summary>
        public static readonly Color Magenta = new Color(255, 0, 255);

        /// <summary>
        /// The color Maroon.
        /// </summary>
        public static readonly Color Maroon = new Color(128, 0, 0);

        /// <summary>
        /// The color MediumAquamarine.
        /// </summary>
        public static readonly Color MediumAquamarine = new Color(102, 205, 170);

        /// <summary>
        /// The color MediumBlue.
        /// </summary>
        public static readonly Color MediumBlue = new Color(0, 0, 205);

        /// <summary>
        /// The color MediumOrchid.
        /// </summary>
        public static readonly Color MediumOrchid = new Color(186, 85, 211);

        /// <summary>
        /// The color MediumPurple.
        /// </summary>
        public static readonly Color MediumPurple = new Color(147, 112, 219);

        /// <summary>
        /// The color MediumSeaGreen.
        /// </summary>
        public static readonly Color MediumSeaGreen = new Color(60, 179, 113);

        /// <summary>
        /// The color MediumSlateBlue.
        /// </summary>
        public static readonly Color MediumSlateBlue = new Color(123, 104, 238);

        /// <summary>
        /// The color MediumSpringGreen.
        /// </summary>
        public static readonly Color MediumSpringGreen = new Color(0, 250, 154);

        /// <summary>
        /// The color MediumTurquoise.
        /// </summary>
        public static readonly Color MediumTurquoise = new Color(72, 209, 204);

        /// <summary>
        /// The color MediumVioletRed.
        /// </summary>
        public static readonly Color MediumVioletRed = new Color(199, 21, 133);

        /// <summary>
        /// The color MidnightBlue.
        /// </summary>
        public static readonly Color MidnightBlue = new Color(25, 25, 112);

        /// <summary>
        /// The color MintCream.
        /// </summary>
        public static readonly Color MintCream = new Color(245, 255, 250);

        /// <summary>
        /// The color MistyRose.
        /// </summary>
        public static readonly Color MistyRose = new Color(255, 228, 225);

        /// <summary>
        /// The color Moccasin.
        /// </summary>
        public static readonly Color Moccasin = new Color(255, 228, 181);

        /// <summary>
        /// The color NavajoWhite.
        /// </summary>
        public static readonly Color NavajoWhite = new Color(255, 222, 173);

        /// <summary>
        /// The color Navy.
        /// </summary>
        public static readonly Color Navy = new Color(0, 0, 128);

        /// <summary>
        /// The color OldLace.
        /// </summary>
        public static readonly Color OldLace = new Color(253, 245, 230);

        /// <summary>
        /// The color Olive.
        /// </summary>
        public static readonly Color Olive = new Color(128, 128, 0);

        /// <summary>
        /// The color OliveDrab.
        /// </summary>
        public static readonly Color OliveDrab = new Color(107, 142, 35);

        /// <summary>
        /// The color Orange.
        /// </summary>
        public static readonly Color Orange = new Color(255, 165, 0);

        /// <summary>
        /// The color OrangeRed.
        /// </summary>
        public static readonly Color OrangeRed = new Color(255, 69, 0);

        /// <summary>
        /// The color Orchid.
        /// </summary>
        public static readonly Color Orchid = new Color(218, 112, 214);

        /// <summary>
        /// The color PaleGoldenrod.
        /// </summary>
        public static readonly Color PaleGoldenrod = new Color(238, 232, 170);

        /// <summary>
        /// The color PaleGreen.
        /// </summary>
        public static readonly Color PaleGreen = new Color(152, 251, 152);

        /// <summary>
        /// The color PaleTurquoise.
        /// </summary>
        public static readonly Color PaleTurquoise = new Color(175, 238, 238);

        /// <summary>
        /// The color PaleVioletRed.
        /// </summary>
        public static readonly Color PaleVioletRed = new Color(219, 112, 147);

        /// <summary>
        /// The color PapayaWhip.
        /// </summary>
        public static readonly Color PapayaWhip = new Color(225, 239, 213);

        /// <summary>
        /// The color PeachPuff.
        /// </summary>
        public static readonly Color PeachPuff = new Color(255, 218, 185);

        /// <summary>
        /// The color Peru.
        /// </summary>
        public static readonly Color Peru = new Color(205, 133, 63);

        /// <summary>
        /// The color Pink.
        /// </summary>
        public static readonly Color Pink = new Color(255, 192, 203);

        /// <summary>
        /// The color Plum.
        /// </summary>
        public static readonly Color Plum = new Color(221, 160, 221);

        /// <summary>
        /// The color PowderBlue.
        /// </summary>
        public static readonly Color PowderBlue = new Color(176, 224, 230);

        /// <summary>
        /// The color Purple.
        /// </summary>
        public static readonly Color Purple = new Color(128, 0, 128);

        /// <summary>
        /// The color Red.
        /// </summary>
        public static readonly Color Red = new Color(255, 0, 0);

        /// <summary>
        /// The color RosyBrown.
        /// </summary>
        public static readonly Color RosyBrown = new Color(188, 143, 143);

        /// <summary>
        /// The color RoyalBlue.
        /// </summary>
        public static readonly Color RoyalBlue = new Color(65, 105, 225);

        /// <summary>
        /// The color SaddleBrown.
        /// </summary>
        public static readonly Color SaddleBrown = new Color(139, 69, 19);

        /// <summary>
        /// The color Salmon.
        /// </summary>
        public static readonly Color Salmon = new Color(250, 128, 114);

        /// <summary>
        /// The color SandyBrown.
        /// </summary>
        public static readonly Color SandyBrown = new Color(244, 164, 96);

        /// <summary>
        /// The color SeaGreen.
        /// </summary>
        public static readonly Color SeaGreen = new Color(46, 139, 87);

        /// <summary>
        /// The color SeaShell.
        /// </summary>
        public static readonly Color SeaShell = new Color(255, 245, 238);

        /// <summary>
        /// The color Sienna.
        /// </summary>
        public static readonly Color Sienna = new Color(160, 82, 45);

        /// <summary>
        /// The color Silver.
        /// </summary>
        public static readonly Color Silver = new Color(192, 192, 192);

        /// <summary>
        /// The color SkyBlue.
        /// </summary>
        public static readonly Color SkyBlue = new Color(135, 206, 235);

        /// <summary>
        /// The color SlateBlue.
        /// </summary>
        public static readonly Color SlateBlue = new Color(106, 90, 205);

        /// <summary>
        /// The color SlateGray.
        /// </summary>
        public static readonly Color SlateGray = new Color(112, 128, 144);

        /// <summary>
        /// The color Snow.
        /// </summary>
        public static readonly Color Snow = new Color(255, 250, 250);

        /// <summary>
        /// The color SpringGreen.
        /// </summary>
        public static readonly Color SpringGreen = new Color(0, 255, 127);

        /// <summary>
        /// The color SteelBlue.
        /// </summary>
        public static readonly Color SteelBlue = new Color(70, 130, 180);

        /// <summary>
        /// The color Tan.
        /// </summary>
        public static readonly Color Tan = new Color(210, 180, 140);

        /// <summary>
        /// The color Teal.
        /// </summary>
        public static readonly Color Teal = new Color(0, 128, 128);

        /// <summary>
        /// The color Thistle.
        /// </summary>
        public static readonly Color Thistle = new Color(216, 191, 216);

        /// <summary>
        /// The color Tomato.
        /// </summary>
        public static readonly Color Tomato = new Color(255, 99, 71);

        /// <summary>
        /// Transparent black color.
        /// </summary>
        public static readonly Color TransparentBlack = new Color(0, 0, 0, 0);

        /// <summary>
        /// Transparent white color.
        /// </summary>
        public static readonly Color TransparentWhite = new Color(255, 255, 255, 0);

        /// <summary>
        /// The color Turquoise.
        /// </summary>
        public static readonly Color Turquoise = new Color(64, 224, 208);

        /// <summary>
        /// The color Violet.
        /// </summary>
        public static readonly Color Violet = new Color(238, 130, 238);

        /// <summary>
        /// The color Wheat.
        /// </summary>
        public static readonly Color Wheat = new Color(245, 222, 179);

        /// <summary>
        /// The color White.
        /// </summary>
        public static readonly Color White = new Color(255, 255, 255);

        /// <summary>
        /// The color WhiteSmoke.
        /// </summary>
        public static readonly Color WhiteSmoke = new Color(245, 245, 245);

        /// <summary>
        /// The color Yellow.
        /// </summary>
        public static readonly Color Yellow = new Color(255, 255, 0);

        /// <summary>
        /// The color YellowGreen.
        /// </summary>
        public static readonly Color YellowGreen = new Color(154, 205, 50);

        #endregion Static pre-defined Colors

        /// <summary>
        /// The red component of the color.
        /// </summary>
        public readonly float R;

        /// <summary>
        /// The green component of the color.
        /// </summary>
        public readonly float G;

        /// <summary>
        /// The blue component of the color.
        /// </summary>
        public readonly float B;

        /// <summary>
        /// The color's alpha value.
        /// </summary>
        public readonly float A;

        /// <summary>
        /// Creates a new color from a <see cref="Color4" /> color.
        /// </summary>
        /// <param name="color">The base <see cref="Color4" /> to use, RGBA will be copied from this color.</param>
        public Color(Color4 color) : this(color.R, color.G, color.B, color.A)
        {
            
        }

        /// <summary>
        /// Creates a new color from a base color with new alpha value.
        /// </summary>
        /// <param name="base">The base color to use, RGB will be copied from this color.</param>
        /// <param name="a">The new alpha value to assign (0-255).</param>
        public Color(Color @base, byte a) : this(@base, a / 255.0f)
        {
            
        }

        /// <summary>
        /// Creates a new color from a base color with new alpha value.
        /// </summary>
        /// <param name="base">The base color to use, RGB will be copied from this color.</param>
        /// <param name="a">The new alpha value to assign (0.0-1.0).</param>
        public Color(Color @base, float a) : this(@base.R, @base.G, @base.B, a)
        {
            
        }

        /// <summary>
        /// Creates a new color with the specified red, green, blue and alpha values.
        /// </summary>
        /// <param name="r">Value of the red component (0-255).</param>
        /// <param name="g">Value of the green component (0-255).</param>
        /// <param name="b">Value of the blue component (0-255).</param>
        /// <param name="a">Alpha value (0-255) where 0 is transparent and 255 is opaque.</param>
        public Color(byte r, byte g, byte b, byte a = 255) : this(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f)
        {
            
        }

        /// <summary>
        /// Creates a new color with the specified red, green, blue and alpha values.
        /// </summary>
        /// <param name="r">Value of the red component (0.0-1.0).</param>
        /// <param name="g">Value of the green component (0.0-1.0).</param>
        /// <param name="b">Value of the blue component (0.0-1.0).</param>
        /// <param name="a">Alpha value (0.0-1.0) where 0.0 is transparent and 1.0 is opauqe.</param>
        public Color(float r, float g, float b, float a = 1.0f)
        {
            R = Helpers.Math.Clamp(r, 0.0f, 1.0f);
            G = Helpers.Math.Clamp(g, 0.0f, 1.0f);
            B = Helpers.Math.Clamp(b, 0.0f, 1.0f);
            A = Helpers.Math.Clamp(a, 0.0f, 1.0f);
        }

        /// <summary>
        /// Returns a <see cref="Vector4" /> representation of this color.
        /// This can be used with most OpenTK methods.
        /// </summary>
        /// <returns><see cref="Vector4" /> representation of this color.</returns>
        [Pure]
        public Vector4 ToVector4()
        {
            return new Vector4(R, G, B, A);
        }

        /// <summary>
        /// Returns a <see cref="Vector3" /> representation of this color (ommits alpha value).
        /// This can be used with most OpenTK methods.
        /// </summary>
        /// <returns><see cref="Vector3" /> representation of this color.</returns>
        [Pure]
        public Vector3 ToVector3()
        {
            return new Vector3(R, G, B);
        }

        /// <summary>
        /// Returns a <see cref="Color4" /> representation of this color.
        /// This can be used with most OpenTK methods.
        /// </summary>
        /// <returns><see cref="Color4" /> representation of this color.</returns>
        [Pure]
        public Color4 ToColor4()
        {
            return new Color4(R, G, B, A);
        }
    }
}
