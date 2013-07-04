using System;
using NUnit.Framework;

namespace TriDevs.TriEngine.Tests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void ShouldCreateFloatPoint()
        {
            var point = new Point<float>(1.0f, 0.75f, 0.5f);
            Assert.AreEqual(point.X, 1.0f);
            Assert.AreEqual(point.Y, 0.75f);
            Assert.AreEqual(point.Z, 0.5f);
        }

        [Test]
        public void ShouldCreateDoublePoint()
        {
            var point = new Point<double>(1.0, 0.75, 0.5);
            Assert.AreEqual(point.X, 1.0);
            Assert.AreEqual(point.Y, 0.75);
            Assert.AreEqual(point.Z, 0.5);
        }

        [Test]
        public void ShouldCreateDecimalPoint()
        {
            var point = new Point<decimal>(1.0M, 0.75M, 0.5M);
            Assert.AreEqual(point.X, 1.0M);
            Assert.AreEqual(point.Y, 0.75M);
            Assert.AreEqual(point.Z, 0.5M);
        }

        [Test]
        public void ShouldCreateBytePoint()
        {
            var point = new Point<byte>(100, 75, 50);
            Assert.AreEqual(point.X, 100);
            Assert.AreEqual(point.Y, 75);
            Assert.AreEqual(point.Z, 50);
        }

        [Test]
        public void ShouldCreateInt16Point()
        {
            var point = new Point<Int16>(100, 75, 50);
            Assert.AreEqual(point.X, 100);
            Assert.AreEqual(point.Y, 75);
            Assert.AreEqual(point.Z, 50);
        }

        [Test]
        public void ShouldCreateUInt16Point()
        {
            var point = new Point<UInt16>(100, 75, 50);
            Assert.AreEqual(point.X, 100);
            Assert.AreEqual(point.Y, 75);
            Assert.AreEqual(point.Z, 50);
        }

        [Test]
        public void ShouldCreateInt32Point()
        {
            var point = new Point<Int32>(100, 75, 50);
            Assert.AreEqual(point.X, 100);
            Assert.AreEqual(point.Y, 75);
            Assert.AreEqual(point.Z, 50);
        }

        [Test]
        public void ShouldCreateUInt32Point()
        {
            var point = new Point<UInt32>(100, 75, 50);
            Assert.AreEqual(point.X, 100);
            Assert.AreEqual(point.Y, 75);
            Assert.AreEqual(point.Z, 50);
        }

        [Test]
        public void ShouldCreateInt64Point()
        {
            var point = new Point<Int64>(100, 75, 50);
            Assert.AreEqual(point.X, 100);
            Assert.AreEqual(point.Y, 75);
            Assert.AreEqual(point.Z, 50);
        }

        [Test]
        public void ShouldCreateUInt64Point()
        {
            var point = new Point<UInt64>(100, 75, 50);
            Assert.AreEqual(point.X, 100);
            Assert.AreEqual(point.Y, 75);
            Assert.AreEqual(point.Z, 50);
        }
    }
}
