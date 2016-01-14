using System;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class LimitSearchFilterTests
    {
        [Test]
        public void TestCanCreate()
        {
            var orderBy = new LimitSearchFilter(10);
            Assert.AreEqual("=", orderBy.Comparison);
            Assert.AreEqual("limit", orderBy.Field);
            Assert.AreEqual("10", orderBy.Value);
        }

        [Test]
        public void TestThrowsExceptionOnInvalidLimit()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.That(() => new LimitSearchFilter(-10), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
