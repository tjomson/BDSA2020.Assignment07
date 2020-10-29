using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose
{
    public class GildedRoseTests
    {
        [Theory]
        [InlineData("bruh", 10, 39, 9, 38)]
        [InlineData("old", 0, 39, -1, 37)]
        [InlineData("Aged Brie", 5, 20, 4, 21)]
        [InlineData("Aged Brie", 0, 20, -1, 22)]
        [InlineData("Sulfuras, Hand of Ragnaros", 1, 80, 1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 25, 10, 26)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 25, 9, 27)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 25, 4, 28)]
        [InlineData("hulabula", -1, 15, -2, 13)]
        [InlineData("Aged Brie", -1, 17, -2, 19)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -1, 10, -2, 0)]
        public void DummyTest(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
        
            List<Item> items = new List<Item>();
            Item item1 = new Item(){Name = name, SellIn = sellIn, Quality = quality};
            items.Add(item1);
            
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            var actual = gildedRose.Items[0];
            Assert.Equal(expectedSellIn, actual.SellIn);
            Assert.Equal(expectedQuality, actual.Quality);
            
        }
    }
}
