using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TriDevs.TriEngine.Extensions;

namespace TriDevs.TriEngine.Tests.ExtensionTests
{
    [TestFixture]
    public class DecimalExtensionTests
    {
        [Test]
        public void ShouldNotClamp()
        {
            Assert.AreEqual((0.5M).Clamp(0.0M, 1.0M), 0.5M);
        }

        [Test]
        public void ShouldClampToMinimum()
        {
            Assert.AreEqual((0.0M).Clamp(0.5M, 1.0M), 0.5M);
        }

        [Test]
        public void ShouldClampToMaximum()
        {
            Assert.AreEqual((1.0M).Clamp(0.0M, 0.5M), 0.5M);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void ClampShouldThrowArgumentException()
        {
            (0.0M).Clamp(10.0M, 0.0M);
        }
    }
}
