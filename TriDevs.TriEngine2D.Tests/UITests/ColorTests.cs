using NUnit.Framework;
using TriDevs.TriEngine2D.UI;

namespace TriDevs.TriEngine2D.Tests.UITests
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
    }
}
