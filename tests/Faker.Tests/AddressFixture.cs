﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class AddressFixture
    {
        [SetUp]
        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture   = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        [Test]
        public void Should_Get_MilitaryStateAbbr()
        {
            var address = Address.UsMilitaryStateAbbr();
            Assert.IsTrue(address.StartsWith("A", StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void Should_Get_MilitaryState()
        {
            var address = Address.UsMilitaryState();
            Assert.IsTrue(address.StartsWith("Armed", StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void Should_Get_Street_Address()
        {
            var address = Address.StreetAddress();
            Console.WriteLine($@"Address=[{address}]");

            Assert.IsTrue(Regex.IsMatch(address, "^[0-9]{3,5} [A-Z][a-z]+ [A-Z][a-z]+$"));
        }

        [Test]
        public void Should_Get_Street_Address_With_Secondary_Address()
        {
            var address = Address.StreetAddress(true);
            Console.WriteLine($@"Address=[{address}]");

            Assert.IsTrue(Regex.IsMatch(address, @"^[0-9]{3,5} [A-Z][a-z]+ [A-Z][a-z]+ [A-Z][a-z]+\.? [0-9]{3}$"));
        }
    }
}
