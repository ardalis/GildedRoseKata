using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class AgedBrieQualityItemUpdateQualityShould
    {
        private const int DefaultSellIn = 10;
        private const int DefaultQuality = 20;

        [Test]
        public void IncreaseQualityOfAgedBrieByOne()
        {
            var item = GetAgedBrie();

            item.UpdateQuality();

            item.Quality.Should().Be(DefaultQuality + 1);
            item.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void NotIncreaseQualityOfAgedBrieBeyondFifty()
        {
            var item = GetAgedBrie(quality: 50);

            item.UpdateQuality();

            item.Quality.Should().Be(50);
            item.SellIn.Should().Be(DefaultSellIn - 1);
        }


        private QualityItem GetAgedBrie(int sellIn = DefaultSellIn, int quality = DefaultQuality)
        {
            return new AgedBrieQualityItem(new Item() { Name = "Aged Brie", SellIn = sellIn, Quality = quality });
        }
    }
}
