namespace GildedRoseKata
{
    class BackstagePassQualityItem : QualityItem
    {
        public BackstagePassQualityItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (this.Quality < 50)
            {
                IncrementQuality();
            }

            this.SellIn = this.SellIn - 1;
            if (this.SellIn < 10)
            {
                IncrementQuality();
            }
            if (this.SellIn < 5)
            {
                IncrementQuality();
            }
            if (this.SellIn < 0)
            {
                DecrementQuality(Quality);
            }
        }
    }
}