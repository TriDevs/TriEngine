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
