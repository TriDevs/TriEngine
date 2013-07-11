using NUnit.Framework;
using OpenTK;
using OpenTK.Graphics;

namespace TriDevs.TriEngine.Tests
{
    [TestFixture]
    public class ColorTests
    {
        [Test]
        public void ShouldCreateColorWithAlpha()
        {
            var color = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            Assert.AreEqual(color.R, 0.1f);
            Assert.AreEqual(color.G, 0.2f);
            Assert.AreEqual(color.B, 0.3f);
            Assert.AreEqual(color.A, 0.4f);
        }

        [Test]
        public void ShouldMakeByteColorIntoWhite()
        {
            var color = new Color(255, 255, 255);
            Assert.AreEqual(color.R, 1.0f);
            Assert.AreEqual(color.G, 1.0f);
            Assert.AreEqual(color.B, 1.0f);
            Assert.AreEqual(color.A, 1.0f);
        }

        [Test]
        public void ShouldCreateColorFromArgbValue()
        {
            // 0xAARRGGBB
            const byte alpha = 0x11;
            const byte red   = 0x22;
            const byte green = 0x33;
            const byte blue  = 0x44;
            const uint val = (alpha << 24) +
                             (red   << 16) +
                             (green <<  8) +
                             (blue  <<  0);
            var color = new Color(val);
            const float fa = alpha / 255.0f;
            const float fr = red / 255.0f;
            const float fg = green / 255.0f;
            const float fb = blue / 255.0f;
            Assert.AreEqual(fa, color.A);
            Assert.AreEqual(fr, color.R);
            Assert.AreEqual(fg, color.G);
            Assert.AreEqual(fb, color.B);
        }

        [Test]
        public void ShouldCreateColorFromRgbaValue()
        {
            // 0xRRGGBBAA
            const byte alpha = 0x11;
            const byte red   = 0x22;
            const byte green = 0x33;
            const byte blue  = 0x44;
            const uint val = (red   << 24) +
                             (green << 16) +
                             (blue  <<  8) +
                             (alpha <<  0);
            var color = Color.FromRgba(val);
            const float fa = alpha / 255.0f;
            const float fr = red / 255.0f;
            const float fg = green / 255.0f;
            const float fb = blue / 255.0f;
            Assert.AreEqual(fa, color.A);
            Assert.AreEqual(fr, color.R);
            Assert.AreEqual(fg, color.G);
            Assert.AreEqual(fb, color.B);
        }

        [Test]
        public void ShouldCreateColorFromBgraValue()
        {
            // 0xBBGGRRAA
            const byte alpha = 0x11;
            const byte red   = 0x22;
            const byte green = 0x33;
            const byte blue  = 0x44;
            const uint val = (blue  << 24) +
                             (green << 16) +
                             (red   <<  8) +
                             (alpha <<  0);
            var color = Color.FromBgra(val);
            const float fa = alpha / 255.0f;
            const float fr = red / 255.0f;
            const float fg = green / 255.0f;
            const float fb = blue / 255.0f;
            Assert.AreEqual(fa, color.A);
            Assert.AreEqual(fr, color.R);
            Assert.AreEqual(fg, color.G);
            Assert.AreEqual(fb, color.B);
        }

        [Test]
        public void ShouldCreateColorFromAbgrValue()
        {
            // 0xAABBGGRR
            const byte alpha = 0x11;
            const byte red   = 0x22;
            const byte green = 0x33;
            const byte blue  = 0x44;
            const uint val = (alpha << 24) +
                             (blue  << 16) +
                             (green <<  8) +
                             (red   <<  0);
            var color = Color.FromAbgr(val);
            const float fa = alpha / 255.0f;
            const float fr = red / 255.0f;
            const float fg = green / 255.0f;
            const float fb = blue / 255.0f;
            Assert.AreEqual(fa, color.A);
            Assert.AreEqual(fr, color.R);
            Assert.AreEqual(fg, color.G);
            Assert.AreEqual(fb, color.B);
        }

        [Test]
        public void ShouldCreateColorFromBaseWithNewByteAlpha()
        {
            var baseColor = new Color(1.0f, 1.0f, 1.0f);
            var newColor = new Color(baseColor, 0);
            Assert.AreEqual(newColor.R, baseColor.R);
            Assert.AreEqual(newColor.G, baseColor.G);
            Assert.AreEqual(newColor.B, baseColor.B);
            Assert.AreEqual(newColor.A, 0.0f);
            Assert.AreEqual(baseColor.A, 1.0f);
        }

        [Test]
        public void ShouldCreateColorFromBaseWithNewFloatAlpha()
        {
            var baseColor = new Color(1.0f, 1.0f, 1.0f);
            var newColor = new Color(baseColor, 0.0f);
            Assert.AreEqual(newColor.R, baseColor.R);
            Assert.AreEqual(newColor.G, baseColor.G);
            Assert.AreEqual(newColor.B, baseColor.B);
            Assert.AreEqual(newColor.A, 0.0f);
            Assert.AreEqual(baseColor.A, 1.0f);
        }

        [Test]
        public void ShouldCreateColorFromVector3()
        {
            var vector = new Vector3(1.0f, 0.5f, 0.0f);
            var color = new Color(vector);
            Assert.AreEqual(color.R, vector.X);
            Assert.AreEqual(color.G, vector.Y);
            Assert.AreEqual(color.B, vector.Z);
            Assert.AreEqual(color.A, 1.0f);
        }

        [Test]
        public void ShouldCreateColorFromVector4()
        {
            var vector = new Vector4(1.0f, 0.5f, 0.0f, 0.75f);
            var color = new Color(vector);
            Assert.AreEqual(color.R, vector.X);
            Assert.AreEqual(color.G, vector.Y);
            Assert.AreEqual(color.B, vector.Z);
            Assert.AreEqual(color.A, vector.W);
        }

        [Test]
        public void ShouldCreateColorFromColor4()
        {
            var color4 = new Color4(1.0f, 0.5f, 0.0f, 0.75f);
            var color = new Color(color4);
            Assert.AreEqual(color.R, color4.R);
            Assert.AreEqual(color.G, color4.G);
            Assert.AreEqual(color.B, color4.B);
            Assert.AreEqual(color.A, color4.A);
        }

        [Test]
        public void ShouldConvertToArgb()
        {
            // 0xAARRGGBB
            const int val = 0x11223344;
            var color = new Color(val);
            var argb = color.ToArgb();
            Assert.AreEqual(val, argb);
        }

        [Test]
        public void ShouldConvertToRgba()
        {
            // 0xRRGGBBAA
            const uint val = 0x22334411;
            var color = Color.FromRgba(val);
            var rgba = color.ToRgba();
            Assert.AreEqual(val, rgba);
        }

        [Test]
        public void ShouldConvertToBgra()
        {
            // 0xBBGGRRAA
            const uint val = 0x44332211;
            var color = Color.FromBgra(val);
            var bgra = color.ToBgra();
            Assert.AreEqual(val, bgra);
        }

        [Test]
        public void ShouldConvertToAbgr()
        {
            // 0xAABBGGRR
            const uint val = 0x11443322;
            var color = Color.FromAbgr(val);
            var abgr = color.ToAbgr();
            Assert.AreEqual(val, abgr);
        }

        [Test]
        public void ShouldConvertToVector3()
        {
            var color = new Color(0.1f, 0.2f, 0.3f);
            var vector = color.ToVector3();
            Assert.AreEqual(vector.X, color.R);
            Assert.AreEqual(vector.Y, color.G);
            Assert.AreEqual(vector.Z, color.B);
        }

        [Test]
        public void ShouldConvertToVector4()
        {
            var color = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            var vector = color.ToVector4();
            Assert.AreEqual(vector.X, color.R);
            Assert.AreEqual(vector.Y, color.G);
            Assert.AreEqual(vector.Z, color.B);
            Assert.AreEqual(vector.W, color.A);
        }

        [Test]
        public void ShouldConvertToColor4()
        {
            var color = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            var color4 = color.ToColor4();
            Assert.AreEqual(color.R, color4.R, "Red component mismatch!");
            Assert.AreEqual(color.G, color4.G, "Green component mismatch!");
            Assert.AreEqual(color.B, color4.B, "Blue component mismatch!");
            Assert.AreEqual(color.A, color4.A, "Alpha component mismatch!");
        }

        [Test]
        public void ShouldReturnValidArgbValue()
        {
            var color = new Color(0.1f, 0.2f, 0.3f, 0.4f);
            var color4 = color.ToColor4();
            var argb = color4.ToArgb();
            var expected =
                (uint) (color4.A * byte.MaxValue) << 24 |
                (uint) (color4.R * byte.MaxValue) << 16 |
                (uint) (color4.G * byte.MaxValue) << 8 |
                (uint) (color4.B * byte.MaxValue);
            Assert.AreEqual(unchecked((int) expected), argb);
        }

        [Test]
        public void ColorShouldEqualColorWithSameValues()
        {
            var color1 = new Color(1.0f, 1.0f, 1.0f);
            var color2 = new Color(1.0f, 1.0f, 1.0f);
            Assert.AreEqual(color1, color2);
        }

        [Test]
        public void ColorShouldNotEqualColorWithDifferentValues()
        {
            var color1 = new Color(1.0f, 1.0f, 1.0f);
            var color2 = new Color(0.0f, 0.0f, 0.0f);
            Assert.AreNotEqual(color1, color2);
        }
    }
}
