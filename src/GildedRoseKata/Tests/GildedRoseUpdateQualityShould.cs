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
        private const int DefaultSellIn = 10;
        private const int DefaultQuality = 20;
        private List<Item> _items;

        [SetUp]
        public void SetUp()
        {
            _items = new List<Item>();
        }
        [Test]
        public void ReduceQualityOfANormalItemByOneIfSellInIs10()
        {
            var item = GetNormalItem();

            var resultItem = UpdateQualityForItem(item);

            resultItem.Quality.Should().Be(DefaultQuality - 1);
            resultItem.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void NotReduceQualityOfANormalItemBelowZero()
        {
            var item = GetNormalItem(quality: 0);

            var resultItem = UpdateQualityForItem(item);

            resultItem.Quality.Should().Be(0);
            resultItem.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void ReduceQualityOfANormalItemByTwoIfSellInIsZero()
        {
            var item = GetNormalItem(sellIn: 0);

            var resultItem = UpdateQualityForItem(item);

            resultItem.Quality.Should().Be(DefaultQuality - 2);
            resultItem.SellIn.Should().Be(-1);
        }

        [Test]
        public void IncreaseQualityOfAgedBrieByOne()
        {
            var item = GetAgedBrie();

            var resultItem = UpdateQualityForItem(item);

            resultItem.Quality.Should().Be(DefaultQuality + 1);
            resultItem.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void NotIncreaseQualityOfAgedBrieBeyondFifty()
        {
            var item = GetAgedBrie(quality: 50);

            var resultItem = UpdateQualityForItem(item);

            resultItem.Quality.Should().Be(50);
            resultItem.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void NotChangeQualityOrSellInOfSulfuras()
        {
            var item = GetSulfuras();

            var resultItem = UpdateQualityForItem(item);

            resultItem.Quality.Should().Be(80);
            resultItem.SellIn.Should().Be(0);
        }

        private Item GetNormalItem(int sellIn = DefaultSellIn, int quality = DefaultQuality)
        {
            return new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };
        }

        private Item GetAgedBrie(int sellIn = DefaultSellIn, int quality = DefaultQuality)
        {
            return new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
        }

        private Item GetSulfuras(int sellIn = 0)
        {
            return new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 80 };
        }

        private Item UpdateQualityForItem(Item item)
        {
            var items = new List<Item>();
            items.Add(item);
            var gildedrose = new GildedRose(items);
            gildedrose.UpdateQuality();

            return items.First();
        }
    }
}
