using System;
using NUnit.Framework;
using TriDevs.TriEngine.Extensions;

namespace TriDevs.TriEngine.Tests.ExtensionTests
{
    [TestFixture]
    public class FloatExtensionTests
    {
        [Test]
        public void ShouldNotClamp()
        {
            Assert.AreEqual((0.5f).Clamp(0.0f, 1.0f), 0.5f);
        }

        [Test]
        public void ShouldClampToMinimum()
        {
            Assert.AreEqual((0.0f).Clamp(0.5f, 1.0f), 0.5f);
        }

        [Test]
        public void ShouldClampToMaximum()
        {
            Assert.AreEqual((1.0f).Clamp(0.0f, 0.5f), 0.5f);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void ClampShouldThrowArgumentException()
        {
            (0.0f).Clamp(10.0f, 0.0f);
        }
    }
}
