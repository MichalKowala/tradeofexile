using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Abstraction
{
    public interface IItemInteractor
    {
        public List<Item> GetPricedUniquesByItemCategory(ItemCategory itemCategory);
        public Price CalculateAveragePrice(List<Price> prices);
        public double CalculateChange(double previous, double current);
    }
}
