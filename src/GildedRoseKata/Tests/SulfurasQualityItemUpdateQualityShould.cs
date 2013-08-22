using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class SulfurasQualityItemUpdateQualityShould
    {
        [Test]
        public void NotChangeQualityOrSellInOfSulfuras()
        {
            var item = GetSulfuras();

            item.UpdateQuality();

            item.Quality.Should().Be(80);
            item.SellIn.Should().Be(0);
        }

        private QualityItem GetSulfuras(int sellIn = 0)
        {
            return new SulfurasQualityItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 80 });
        }
    }
}
