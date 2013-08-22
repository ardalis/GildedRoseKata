using System.Collections.Generic;

namespace GildedRoseKata
{
    class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var qualityItem = QualityItem.CreateFromItem(item);
                qualityItem.UpdateQuality();
            }
        }
    }
}