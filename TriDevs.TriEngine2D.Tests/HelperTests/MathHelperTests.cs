using System;
using NUnit.Framework;

namespace TriDevs.TriEngine2D.Tests.HelperTests
{
    [TestFixture]
    public class MathHelperTests
    {
        [Test]
        public void NonClampTest()
        {
            var f  = Helpers.Math.Clamp(          0.5f,       0.0f,       1.0f );
            var d  = Helpers.Math.Clamp(          0.5,        0.0,        1.0  );
            var i  = Helpers.Math.Clamp(          3,          0,          5    );
            var ui = Helpers.Math.Clamp( (uint)   3,          0,          5    );
            var l  = Helpers.Math.Clamp( (long)   3,          0,          5    );
            var ul = Helpers.Math.Clamp( (ulong)  3,          0,          5    );
            var b  = Helpers.Math.Clamp( (byte)   3, (byte)   0, (byte)   5    );
            var s  = Helpers.Math.Clamp( (short)  3, (short)  0, (short)  5    );
            var us = Helpers.Math.Clamp( (ushort) 3, (ushort) 0, (ushort) 5    );
            
            Assert.AreEqual( f,  0.5f );
            Assert.AreEqual( d,  0.5  );
            Assert.AreEqual( i,  3    );
            Assert.AreEqual( ui, 3    );
            Assert.AreEqual( l,  3    );
            Assert.AreEqual( ul, 3    );
            Assert.AreEqual( b,  3    );
            Assert.AreEqual( s,  3    );
            Assert.AreEqual( us, 3    );
        }

        [Test]
        public void MinClampTest()
        {
            var f  = Helpers.Math.Clamp(         -1.5f,       0.0f,        1.0f );
            var d  = Helpers.Math.Clamp(         -1.5,        0.0,         1.0  );
            var i  = Helpers.Math.Clamp(         -3,          0,           5    );
            var ui = Helpers.Math.Clamp( (uint)   3,          5,          10    );
            var l  = Helpers.Math.Clamp( (long)  -3,          0,           5    );
            var ul = Helpers.Math.Clamp( (ulong)  3,          5,          10    );
            var b  = Helpers.Math.Clamp( (byte)   3, (byte)   5, (byte)   10    );
            var s  = Helpers.Math.Clamp( (short) -3, (short)  0, (short)   5    );
            var us = Helpers.Math.Clamp( (ushort) 3, (ushort) 5, (ushort) 10    );
            
            Assert.AreEqual( f,  0.0f );
            Assert.AreEqual( d,  0.0  );
            Assert.AreEqual( i,  0    );
            Assert.AreEqual( ui, 5    );
            Assert.AreEqual( l,  0    );
            Assert.AreEqual( ul, 5    );
            Assert.AreEqual( b,  5    );
            Assert.AreEqual( s,  0    );
            Assert.AreEqual( us, 5    );
        }

        [Test]
        public void MaxClampTest()
        {
            var f  = Helpers.Math.Clamp(           1.5f,       0.0f,       1.0f );
            var d  = Helpers.Math.Clamp(           1.5,        0.0,        1.0  );
            var i  = Helpers.Math.Clamp(          10,          0,          5    );
            var ui = Helpers.Math.Clamp( (uint)   10,          0,          5    );
            var l  = Helpers.Math.Clamp( (long)   10,          0,          5    );
            var ul = Helpers.Math.Clamp( (ulong)  10,          0,          5    );
            var b  = Helpers.Math.Clamp( (byte)   10, (byte)   0, (byte)   5    );
            var s  = Helpers.Math.Clamp( (short)  10, (short)  0, (short)  5    );
            var us = Helpers.Math.Clamp( (ushort) 10, (ushort) 0, (ushort) 5    );
            
            Assert.AreEqual( f,  1.0f );
            Assert.AreEqual( d,  1.0  );
            Assert.AreEqual( i,  5    );
            Assert.AreEqual( ui, 5    );
            Assert.AreEqual( l,  5    );
            Assert.AreEqual( ul, 5    );
            Assert.AreEqual( b,  5    );
            Assert.AreEqual( s,  5    );
            Assert.AreEqual( us, 5    );
        }

        [Test]
        public void ExceptionClampTest()
        {
            const int expectedExceptions = 9;
            int exceptionCount = 0;

            try
            {
                Helpers.Math.Clamp(0.5f, 1.0f, 0.0f);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            try
            {
                Helpers.Math.Clamp(0.5, 1.0, 0.0);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            try
            {
                Helpers.Math.Clamp(5, 10, 0);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            try
            {
                Helpers.Math.Clamp((uint) 5, 10, 0);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            try
            {
                Helpers.Math.Clamp((long) 5, 10, 0);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            try
            {
                Helpers.Math.Clamp((ulong) 5, 10, 0);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            try
            {
                Helpers.Math.Clamp((byte) 5, (byte) 10, (byte) 0);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            try
            {
                Helpers.Math.Clamp((short) 5, (short) 10, (short) 0);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            try
            {
                Helpers.Math.Clamp((ushort) 5, (ushort) 10, (ushort) 0);
            }
            catch (ArgumentException)
            {
                exceptionCount++;
            }

            Assert.AreEqual(exceptionCount, expectedExceptions, "All Clamp methods did not throw the expected exception!");
        }
    }
}
