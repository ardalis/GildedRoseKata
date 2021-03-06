﻿using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class NormalQualityItemUpdateQualityShould
    {
        private const int DefaultSellIn = 10;
        private const int DefaultQuality = 20;

        [Test]
        public void ReduceQualityOfANormalItemByOneIfSellInIs10()
        {
            var item = GetNormalItem();

            item.UpdateQuality();

            item.Quality.Should().Be(DefaultQuality - 1);
            item.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void NotReduceQualityOfANormalItemBelowZero()
        {
            var item = GetNormalItem(quality: 0);

            item.UpdateQuality();

            item.Quality.Should().Be(0);
            item.SellIn.Should().Be(DefaultSellIn - 1);
        }

        [Test]
        public void ReduceQualityOfANormalItemByTwoIfSellInIsZero()
        {
            var item = GetNormalItem(sellIn: 0);

            item.UpdateQuality();

            item.Quality.Should().Be(DefaultQuality - 2);
            item.SellIn.Should().Be(-1);
        }

        [Test]
        public void ReduceQualityOfANormalItemByOneIfStartsAt1IfSellInIsZero()
        {
            var item = GetNormalItem(quality: 1, sellIn: 0);

            item.UpdateQuality();

            item.Quality.Should().Be(0);
            item.SellIn.Should().Be(-1);
        }

        private QualityItem GetNormalItem(int sellIn = DefaultSellIn, int quality = DefaultQuality)
        {
            return new NormalQualityItem(new Item() { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality });
        }
    }
}
