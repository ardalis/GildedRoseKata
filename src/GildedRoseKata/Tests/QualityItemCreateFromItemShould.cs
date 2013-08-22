using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class QualityItemCreateFromItemShould
    {
        [Test]
        public void ReturnNormalQualityItemGivenNormalItem()
        {
            var item = QualityItem.CreateFromItem(new Item() { Name = "+5 Dexterity Vest" });

            item.Should().BeOfType<NormalQualityItem>();
        }

        [Test]
        public void ReturnAgedBrieQualityItemGivenAgedBrieItem()
        {
            var item = QualityItem.CreateFromItem(new Item() { Name = "Aged Brie" });

            item.Should().BeOfType<AgedBrieQualityItem>();
        }

        [Test]
        public void ReturnSulfurasQualityItemGivenSulfurasItem()
        {
            var item = QualityItem.CreateFromItem(new Item() { Name = "Sulfuras, Hand of Ragnaros" });

            item.Should().BeOfType<SulfurasQualityItem>();
        }

        [Test]
        public void ReturnBackstagePassQualityItemGivenBackstagePassItem()
        {
            var item = QualityItem.CreateFromItem(new Item() { Name = "Backstage passes to a TAFKAL80ETC concert" });

            item.Should().BeOfType<BackstagePassQualityItem>();
        }
    }
}
