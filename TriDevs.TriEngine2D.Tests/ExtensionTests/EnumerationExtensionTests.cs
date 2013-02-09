using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TriDevs.TriEngine2D.Extensions;

namespace TriDevs.TriEngine2D.Tests.ExtensionTests
{
	[TestFixture]
	public class EnumerationExtensionTests
	{
		[Flags]
		private enum TestEnum
		{
			Foo = 1,
			Bar = 2,
			Baz = 4
		}

		[Test]
		public void HasTest()
		{
			Assert.True(TestEnum.Foo.Has(TestEnum.Foo));
		}

		[Test]
		public void MissingTest()
		{
			Assert.True(TestEnum.Bar.Missing(TestEnum.Foo));
		}

		[Test]
		public void IncludeTest()
		{
			var val = TestEnum.Foo;
			val = val.Include(TestEnum.Bar);
			Assert.True(val.Has(TestEnum.Foo));
			Assert.True(val.Has(TestEnum.Bar));
		}

		[Test]
		public void RemoveTest()
		{
			var val = TestEnum.Foo.Include(TestEnum.Bar);
			val = val.Remove(TestEnum.Foo);
			Assert.True(val.Has(TestEnum.Bar));
			Assert.True(val.Missing(TestEnum.Foo));
		}
	}
}
