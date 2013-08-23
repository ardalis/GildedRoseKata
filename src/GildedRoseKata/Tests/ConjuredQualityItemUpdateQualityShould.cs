using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class ConjuredQualityItemUpdateQualityShould
    {
        private const int DefaultSellIn = 10;
        private const int DefaultQuality = 20;

        [Test]
        public void ReduceQualityByTwoIfSellInIs10()
        {
            var item = GetConjuredItem();

            item.UpdateQuality();

            item.Quality.Should().Be(DefaultQuality - 2);
            item.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void NotReduceQualityBelowZero()
        {
            var item = GetConjuredItem(quality: 0);

            item.UpdateQuality();

            item.Quality.Should().Be(0);
            item.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void ReduceQualityByFourIfSellInIsZero()
        {
            var item = GetConjuredItem(sellIn: 0);

            item.UpdateQuality();

            item.Quality.Should().Be(DefaultQuality - 4);
            item.SellIn.Should().Be(-1);
        }

        [Test]
        public void ReduceQualityByOneIfStartsAt1AndSellInIsZero()
        {
            var item = GetConjuredItem(quality: 1, sellIn: 0);

            item.UpdateQuality();

            item.Quality.Should().Be(0);
            item.SellIn.Should().Be(-1);
        }

        private QualityItem GetConjuredItem(int sellIn = DefaultSellIn, int quality = DefaultQuality)
        {
            return new ConjuredQualityItem(new Item() { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality });
        }
    }
}
