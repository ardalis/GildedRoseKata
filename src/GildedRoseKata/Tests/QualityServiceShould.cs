using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class QualityServiceShould
    {
        [Test]
        public void Pass()
        {
            var item = new Item();

            item.Should().NotBeNull();
        }
    }
}
