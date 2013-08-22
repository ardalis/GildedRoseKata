namespace GildedRoseKata
{
    class AgedBrieQualityItem : QualityItem
    {
        public AgedBrieQualityItem(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (this.Quality < 50)
            {
                IncrementQuality();
            }

            this.SellIn = this.SellIn - 1;
        }
    }
}