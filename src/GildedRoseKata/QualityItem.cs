using System;

namespace GildedRoseKata
{
    abstract class QualityItem
    {
        private readonly Item _item;

        public QualityItem(Item item)
        {
            this._item = item;
        }

        public static QualityItem CreateFromItem(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                return new AgedBrieQualityItem(item);
            }
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return new SulfurasQualityItem(item);
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new BackstagePassQualityItem(item);
            }
            return new NormalQualityItem(item);
        }

        public string Name
        {
            get
            {
                return _item.Name;
            }
            set
            {
                _item.Name = value;
            }
        }

        public int Quality
        {
            get
            {
                return _item.Quality;
            }
            set
            {
                _item.Quality = value;
            }
        }

        public int SellIn
        {
            get
            {
                return _item.SellIn;
            }
            set
            {
                _item.SellIn = value;
            }
        }

        protected void IncrementQuality()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
        }

        protected void DecrementQuality(int amount = 1)
        {
            if (Quality > 0)
            {
                Quality = Quality - amount;
            }
        }

        public abstract void UpdateQuality();
    }
}