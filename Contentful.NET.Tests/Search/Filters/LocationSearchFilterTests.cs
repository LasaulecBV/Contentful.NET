using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Filters;
using NUnit.Framework;

namespace Contentful.NET.Tests.Search.Filters
{
    [TestFixture]
    public class LocationSearchFilterTests
    {
        [Test]
        public void TestCreateLocationNearSearch()
        {
            const string propertyName = "query";
            const string equalityValue = "42.14,54.22";
            var filter = new LocationSearchFilter(propertyName, 42.14m, 54.22m);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LocationNear.ToString(), filter.Comparison);
        }

        [Test]
        public void TestLocationNearThrowsExceptionOnInvalidPropertyName()
        {
            Assert.That(() => new LocationSearchFilter(null, 42.14m, 54.22m), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestLocationNearThrowsExceptionOnInvalidLatitude()
        {
            Assert.That(() => new LocationSearchFilter("property", -180, 90), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestLocationNearThrowsExceptionOnInvalidLongitude()
        {
            Assert.That(() => new LocationSearchFilter("property", 45, 200), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestCreateLocationWithinSearch()
        {
            const string propertyName = "query";
            const string equalityValue = "42.14,54.22,43.14,56.22";
            var filter = new LocationSearchFilter(propertyName, 42.14m, 54.22m, 43.14m, 56.22m);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LocationWithin.ToString(), filter.Comparison);
        }

        [Test]
        public void TestLocationWithinThrowsExceptionOnInvalidPropertyName()
        {
            Assert.That(() => new LocationSearchFilter("", 42.14m, 54.22m, 43.14m, 56.22m), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestLocationRadiusThrowsExceptionOnInvalidLatitude()
        {
            Assert.That(() => new LocationSearchFilter("property", -180, 90, 45), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestLocationRadiusThrowsExceptionOnInvalidLongitude()
        {
            Assert.That(() => new LocationSearchFilter("property", 45, 200, 45), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestCreateLocationRadiusSearch()
        {
            const string propertyName = "query";
            const string equalityValue = "42.14,54.22,43.14";
            var filter = new LocationSearchFilter(propertyName, 42.14m, 54.22m, 43.14m);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LocationWithin.ToString(), filter.Comparison);
        }

        [Test]
        public void TestLocationRadiusThrowsExceptionOnInvalidPropertyName()
        {
            Assert.That(() => new LocationSearchFilter("", 42.14m, 54.22m, 43.14m), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestLocationWithinThrowsExceptionOnInvalidFirstLatitude()
        {
            Assert.That(() => new LocationSearchFilter("property", -180, 90, 45, 45), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestLocationWithinThrowsExceptionOnInvalidFirstLongitude()
        {
            Assert.That(() => new LocationSearchFilter("property", 45, 200, 45, 45), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestLocationWithinThrowsExceptionOnInvalidSecondLatitude()
        {
            Assert.That(() => new LocationSearchFilter("property", 45, 45, -180, 90), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestLocationWithinThrowsExceptionOnInvalidSecondLongitude()
        {
            Assert.That(() => new LocationSearchFilter("property", 45, 45, 45, 200), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
