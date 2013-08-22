using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class BackstagePassQualityItemUpdateQualityShould
    {
        private const int DefaultSellIn = 10;
        private const int DefaultQuality = 20;

        [Test]
        public void IncreaseQualityByOneOfBackstagePassesWithSellInOfEleven()
        {
            var item = GetBackstagePasses(sellIn: 11);

            item.UpdateQuality();

            item.Quality.Should().Be(DefaultQuality + 1);
            item.SellIn.Should().Be(10);
        }

        [Test]
        public void IncreaseQualityByTwoOfBackstagePassesWithSellInOfTen()
        {
            var item = GetBackstagePasses();

            item.UpdateQuality();

            item.Quality.Should().Be(DefaultQuality + 2);
            item.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void IncreaseQualityByThreeOfBackstagePassesWithSellInOfFive()
        {
            var item = GetBackstagePasses(sellIn: 5);

            item.UpdateQuality();

            item.Quality.Should().Be(DefaultQuality + 3);
            item.SellIn.Should().Be(4);
        }

        [Test]
        public void SetQualityToZeroForBackstagePassesWithSellInOfZero()
        {
            var item = GetBackstagePasses(sellIn: 0);

            item.UpdateQuality();

            item.Quality.Should().Be(0);
            item.SellIn.Should().Be(-1);
        }


        private QualityItem GetBackstagePasses(int sellIn = DefaultSellIn, int quality = DefaultQuality)
        {
            return new BackstagePassQualityItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }
    }
}
