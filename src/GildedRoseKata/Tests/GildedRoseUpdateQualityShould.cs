using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class GildedRoseUpdateQualityShould
    {
        [Test]
        public void ReduceQualityOfANormalItemByOneIfSellInIs10()
        {
            var items = new List<Item>();
            items.Add(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });

            var gildedrose = new GildedRose(items);
            gildedrose.UpdateQuality();

            var firstItem = items.First();

            firstItem.Quality.Should().Be(19);
            firstItem.SellIn.Should().Be(9);
        }

        [Test]
        public void NotReduceQualityOfANormalItemBelowZero()
        {
            var items = new List<Item>();
            items.Add(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 });

            var gildedrose = new GildedRose(items);
            gildedrose.UpdateQuality();

            var firstItem = items.First();

            firstItem.Quality.Should().Be(0);
            firstItem.SellIn.Should().Be(9);
        }
    }
}
