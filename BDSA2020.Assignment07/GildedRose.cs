using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items { get; }

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                bool isConjured = item.Name.Contains("Conjured");
                int conjuredMultiplier = isConjured ? 2 : 1;
                bool isLegendary = false;
                switch (item.Name)
                {
                    case "Aged Brie":
                        if (item.SellIn > 0) item.Quality++;
                        else item.Quality += 2;
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        isLegendary = true;
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (item.SellIn < 0) item.Quality = 0;
                        else if (item.SellIn < 6) item.Quality += 3;
                        else if (item.SellIn < 11) item.Quality += +2;
                        else item.Quality++;
                        break;
                    default:
                        if (item.Quality > 0) item.Quality -= conjuredMultiplier;
                        if (item.SellIn < 1) item.Quality -= conjuredMultiplier;
                        break;
                }
                if (!isLegendary) item.SellIn--;
                if (item.Quality > 50 && !isLegendary) item.Quality = 50;
                else if (item.Quality < 0) item.Quality = 0;
            }
        }
    }
}
