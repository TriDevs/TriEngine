using NUnit.Framework;
using OpenTK;
using TriDevs.TriEngine.Extensions;

namespace TriDevs.TriEngine.Tests.ExtensionTests
{
    [TestFixture]
    public class Vector4ExtensionTests
    {
        [Test]
        public void ShouldConvertVector4ToFloatArray()
        {
            var vector = new Vector4(0.75f, 0.5f, 0.25f, 0.1f);
            var array = vector.ToFloatArray();

            Assert.AreEqual(array[0], vector.X);
            Assert.AreEqual(array[1], vector.Y);
            Assert.AreEqual(array[2], vector.Z);
            Assert.AreEqual(array[3], vector.W);
        }

        [Test]
        public void ShouldConvertVector4ArrayToFloatArray()
        {
            var vectors = new[]
            {
                new Vector4(0.75f, 0.5f, 0.25f, 0.1f),
                new Vector4(0.1f, 0.25f, 0.5f, 0.75f)
            };

            var array = vectors.ToFloatArray();

            for (var i = 0; i < vectors.Length; i++)
            {
                var index = i * 4;

                Assert.AreEqual(array[index], vectors[i].X);
                Assert.AreEqual(array[index + 1], vectors[i].Y);
                Assert.AreEqual(array[index + 2], vectors[i].Z);
                Assert.AreEqual(array[index + 3], vectors[i].W);
            }
        }
    }
}
