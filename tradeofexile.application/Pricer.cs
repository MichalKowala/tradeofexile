using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Items;
using System.Linq;

namespace tradeofexile.infrastructure
{
    public static class Pricer
    {
        public static void UpdateExchangeTable(Item item)
        {
            CurrencyType currencyType = CurrencyType.Unspecified;
            if (Parser.stringToEnumCurrency.ContainsKey(item.Extended.BaseType))
                currencyType = Parser.stringToEnumCurrency[item.Extended.BaseType];
            if (currencyType != CurrencyType.Unspecified)
            {
                if (ExchangeTable.ContainsKey(currencyType))
                {
                    ExchangeTable[currencyType].Add(item.Price);
                }
                else
                {
                    ExchangeTable.Add(currencyType, new List<Price>() { item.Price });
                }
            }
        }
        public static Price GetRate(CurrencyType pay, CurrencyType get)
        {
            if (ExchangeTable.ContainsKey(pay))
            {
                double ammount = 0;
                int divider = 0;
                List<Price> offers = ExchangeTable[pay];
                foreach (Price p in offers)
                {

                    if (p.CurrencyType == get)
                    {
                        ammount += p.Ammount;
                        divider++;
                    }
                    else
                    {
                        Price p2 = GetRate(p.CurrencyType, get);
                        ammount += p2.Ammount * p.Ammount;
                        divider++;
                    }
                }
                return new Price(ammount / divider, get);
            }
            else return new Price(1, pay);
        }

        public static void AddPricedItemToDictionary(Item item)
        {
            if (ItemsWithOffers.Keys.Where(x => x.Name == item.Name).Any())
            {
                Item i = ItemsWithOffers.Keys.Where(x => x.Name == item.Name).First();
                ItemsWithOffers[i].Add(item.Price);
            }
            else
            {
                ItemsWithOffers.Add(item, new List<Price>() { item.Price });
            }
        }

        public static Dictionary<CurrencyType, List<Price>> ExchangeTable = new Dictionary<CurrencyType, List<Price>>();
        public static Dictionary<Item, List<Price>> ItemsWithOffers = new Dictionary<Item, List<Price>>();
    }
}
