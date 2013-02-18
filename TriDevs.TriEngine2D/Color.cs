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

using OpenTK;

namespace TriDevs.TriEngine2D
{
    /// <summary>
    /// Represents an RGBA color that can be used with TriEngine2D.
    /// </summary>
    public struct Color
    {
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
            R = 0.0f;
            R = Helpers.Math.Clamp(r, 0.0f, 1.0f);
            G = Helpers.Math.Clamp(g, 0.0f, 1.0f);
            B = Helpers.Math.Clamp(b, 0.0f, 1.0f);
            A = Helpers.Math.Clamp(a, 0.0f, 1.0f);
        }

        /// <summary>
        /// Returns a <see cref="Vector4" /> representation of this color.
        /// This can be used with most OpenTK methods.
        /// </summary>
        /// <returns></returns>
        public Vector4 ToVector4()
        {
            return new Vector4(R, G, B, A);
        }

        /// <summary>
        /// Returns a <see cref="Vector3" /> representation of this color (ommits alpha value).
        /// This can be used with most OpenTK methods.
        /// </summary>
        /// <returns></returns>
        public Vector3 ToVector3()
        {
            return new Vector3(R, G, B);
        }
    }
}
