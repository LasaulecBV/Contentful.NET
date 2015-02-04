﻿using System;
using Contentful.NET.Search;
using Contentful.NET.Search.Enums;
using Contentful.NET.Search.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contentful.NET.Tests.Search
{
    [TestClass]
    public class NumericSearchFilterTests
    {
        [TestMethod]
        public void TestCreateLessThan()
        {
            const string propertyName = "prop";
            const string equalityValue = "15";
            var filter = new NumericSearchFilter(propertyName, 15, NumericEquality.LessThan);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LessThan.ToString(), filter.Comparison);
        }

        [TestMethod]
        public void TestCreateLessThanEqual()
        {
            const string propertyName = "prop";
            const string equalityValue = "15";
            var filter = new NumericSearchFilter(propertyName, 15, NumericEquality.LessThanEqualTo);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.LessThanEqual.ToString(), filter.Comparison);
        }

        [TestMethod]
        public void TestCreateGreaterThan()
        {
            const string propertyName = "prop";
            const string equalityValue = "15";
            var filter = new NumericSearchFilter(propertyName, 15, NumericEquality.GreaterThan);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.GreaterThan.ToString(), filter.Comparison);
        }

        [TestMethod]
        public void TestCreateGreaterThanEqual()
        {
            const string propertyName = "prop";
            const string equalityValue = "15";
            var filter = new NumericSearchFilter(propertyName, 15, NumericEquality.GreaterThanEqualTo);
            Assert.AreEqual(propertyName, filter.Field);
            Assert.AreEqual(equalityValue, filter.Value);
            Assert.AreEqual(SearchFilterComparer.GreaterThanEqual.ToString(), filter.Comparison);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThrowsExceptionOnInvalidPropertyName()
        {
            new NumericSearchFilter(null, 15, NumericEquality.GreaterThanEqualTo);
        }
    }
}
