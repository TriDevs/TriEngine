using System.Threading;
using NUnit.Framework;
using TriDevs.TriEngine.Helpers;

namespace TriDevs.TriEngine.Tests.HelperTests
{
    [TestFixture]
    public class ThreadingHelperTests
    {
        private const string NewThreadName = "NewName";

        [Test]
        public void SetCurrentThreadNameTest()
        {
            string expected = NewThreadName;
            if (!string.IsNullOrEmpty(Thread.CurrentThread.Name))
                expected = Thread.CurrentThread.Name;
            Threading.SetCurrentThreadName(NewThreadName);
            Assert.AreEqual(Thread.CurrentThread.Name, expected);
        }

        [Test]
        public void SetCurrentThreadNameExistingTest()
        {
            const string expected = "OldName";
            string resultName = null;
            var thread = new Thread(() =>
            {
                Threading.SetCurrentThreadName(expected);
                Threading.SetCurrentThreadName(NewThreadName);
                resultName = Thread.CurrentThread.Name;
            });
            thread.Start();
            thread.Join();
            Assert.AreEqual(resultName, expected);
        }
    }
}
