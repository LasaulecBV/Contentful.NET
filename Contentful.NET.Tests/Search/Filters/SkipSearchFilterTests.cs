﻿using System;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class SkipSearchFilterTests
    {
        [Test]
        public void TestCanCreate()
        {
            var orderBy = new SkipSearchFilter(10);
            Assert.AreEqual("=", orderBy.Comparison);
            Assert.AreEqual("skip", orderBy.Field);
            Assert.AreEqual("10", orderBy.Value);
        }

        [Test]
        public void TestThrowsExceptionOnInvalidLimit()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.That(() => new SkipSearchFilter(-10), Throws.TypeOf<ArgumentException>());
        }
    }
}
