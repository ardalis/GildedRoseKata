namespace GildedRoseKata
{
    class ConjuredQualityItem : QualityItem
    {
        public ConjuredQualityItem(Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            DecrementQuality();
            DecrementQuality();

            this.SellIn = this.SellIn - 1;

            if (this.SellIn < 0)
            {
                DecrementQuality();
                DecrementQuality();
            }
        }
    }
}