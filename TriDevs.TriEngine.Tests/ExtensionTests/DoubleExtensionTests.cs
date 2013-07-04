using System;
using NUnit.Framework;
using TriDevs.TriEngine.Extensions;

namespace TriDevs.TriEngine.Tests.ExtensionTests
{
    [TestFixture]
    public class DoubleExtensionTests
    {
        [Test]
        public void ShouldNotClamp()
        {
            Assert.AreEqual((0.5).Clamp(0.0, 1.0), 0.5);
        }

        [Test]
        public void ShouldClampToMinimum()
        {
            Assert.AreEqual((0.0).Clamp(0.5, 1.0), 0.5);
        }

        [Test]
        public void ShouldClampToMaximum()
        {
            Assert.AreEqual((1.0).Clamp(0.0, 0.5), 0.5);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void ClampShouldThrowArgumentException()
        {
            (0.0).Clamp(10.0, 0.0);
        }
    }
}
