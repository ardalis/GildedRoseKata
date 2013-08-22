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

        public virtual void UpdateQuality()
        {
            if (this.Name != "Aged Brie" && this.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (this.Quality > 0)
                {
                    if (this.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        this.Quality = this.Quality - 1;
                    }
                }
            }
            else
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;

                    if (this.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (this.SellIn < 11)
                        {
                            if (this.Quality < 50)
                            {
                                this.Quality = this.Quality + 1;
                            }
                        }

                        if (this.SellIn < 6)
                        {
                            if (this.Quality < 50)
                            {
                                this.Quality = this.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (this.Name != "Sulfuras, Hand of Ragnaros")
            {
                this.SellIn = this.SellIn - 1;
            }

            if (this.SellIn < 0)
            {
                if (this.Name != "Aged Brie")
                {
                    if (this.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (this.Quality > 0)
                        {
                            if (this.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                this.Quality = this.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        this.Quality = this.Quality - this.Quality;
                    }
                }
                else
                {
                    if (this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;
                    }
                }
            }
        }
    }
}