using System;
using NUnit.Framework;
using TriDevs.TriEngine.Extensions;

namespace TriDevs.TriEngine.Tests.ExtensionTests
{
    [TestFixture]
    public class ByteExtensionTests
    {
        [Test]
        public void ShouldNotClamp()
        {
            Assert.AreEqual(((byte) 5).Clamp(0, 10), 5);
        }

        [Test]
        public void ShouldClampToMinimum()
        {
            Assert.AreEqual(((byte) 0).Clamp(5, 10), 5);
        }

        [Test]
        public void ShouldClampToMaximum()
        {
            Assert.AreEqual(((byte) 15).Clamp(0, 10), 10);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void ClampShouldThrowArgumentException()
        {
            ((byte) 5).Clamp(10, 5);
        }
    }
}
