using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Items;

namespace tradeofexile.application.Abstraction
{
    public interface IItemInteractor
    {
        public List<Item> StackDuplicateItems(List<Item> items);
        public Price GetAveragedPrice(List<Price> pricesToAverage, CurrencyType targetCurrency = CurrencyType.ChaosOrb);
        public List<Item> GetPricedUniquesByItemCategory(ItemCategory itemCategory);
    }
}
