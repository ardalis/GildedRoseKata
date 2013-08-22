namespace GildedRoseKata
{
    class NormalQualityItem : QualityItem
    {
        public NormalQualityItem(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (this.Quality > 0)
            {
                this.Quality = this.Quality - 1;
            }

            this.SellIn = this.SellIn - 1;

            if (this.SellIn < 0)
            {
                this.Quality = this.Quality - 1;
            }
        }
    }
}