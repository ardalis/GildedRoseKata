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
            DecrementQuality();

            this.SellIn = this.SellIn - 1;

            if (this.SellIn < 0)
            {
                DecrementQuality();
            }
        }
    }
}