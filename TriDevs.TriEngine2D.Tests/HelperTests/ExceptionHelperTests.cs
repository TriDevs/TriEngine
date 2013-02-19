using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TriDevs.TriEngine2D.Helpers;

namespace TriDevs.TriEngine2D.Tests.HelperTests
{
    [TestFixture]
    public class ExceptionHelperTests
    {
        [Test]
        [ExpectedException(typeof (EngineException))]
        public void ShouldThrowEngineExceptionWhenPassedGeneric()
        {
            Exceptions.Throw(new Exception());
        }

        [Test]
        [ExpectedException(typeof (EngineException), ExpectedMessage = "Original Exception Message")]
        public void ShouldThrowUnmodifiedEngineException()
        {
            var ex = new EngineException("Original Exception Message");
            // The message passed in as parameter shouldn't be used
            Exceptions.Throw(ex, "New Exception Message");
        }
    }
}
