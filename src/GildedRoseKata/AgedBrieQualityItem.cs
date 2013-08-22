namespace GildedRoseKata
{
    class AgedBrieQualityItem : QualityItem
    {
        public AgedBrieQualityItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (this.Quality < 50)
            {
                this.Quality = this.Quality + 1;
            }

            this.SellIn = this.SellIn - 1;
        }
    }
}