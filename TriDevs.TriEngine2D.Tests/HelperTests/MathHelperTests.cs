using NUnit.Framework;

namespace TriDevs.TriEngine2D.Tests.HelperTests
{
    [TestFixture]
    public class MathHelperTests
    {
        [Test]
        public void ClampTest()
        {
            var f  = Helpers.Math.Clamp(          -1.5f,            0.0f,           1.0f );
            var d  = Helpers.Math.Clamp(           1.5,             0.0,            1.0  );
            var i  = Helpers.Math.Clamp(         -10,               0,              5    );
            var ui = Helpers.Math.Clamp( (uint)   10,               0,              5    );
            var l  = Helpers.Math.Clamp( (long)  -10,               0,              5    );
            var ul = Helpers.Math.Clamp( (ulong)  10,               0,              5    );
            var b  = Helpers.Math.Clamp( (byte)   5,    (byte)     10, (byte)      50    );
            var s  = Helpers.Math.Clamp( (short) -1000, (short)  1000, (short)   3000    );
            var us = Helpers.Math.Clamp( (ushort) 1000, (ushort) 5000, (ushort) 10000    );
            
            Assert.AreEqual( f,     0.0f );
            Assert.AreEqual( d,     1.0  );
            Assert.AreEqual( i,     0    );
            Assert.AreEqual( ui,    5    );
            Assert.AreEqual( l,     0    );
            Assert.AreEqual( ul,    5    );
            Assert.AreEqual( b,    10    );
            Assert.AreEqual( s,  1000    );
            Assert.AreEqual( us, 5000    );
        }
    }
}
