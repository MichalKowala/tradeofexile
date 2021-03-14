using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Items;
using System.Linq;
using tradeofexile.application.Abstraction;

namespace tradeofexile.infrastructure
{
    public  class Pricer : IPricer
    {
        IParser _parser;
        public Pricer(IParser parser)
        {
            _parser = parser;
        }
        public  void UpdateExchangeTable(Item item)
        {
            CurrencyType currencyType = CurrencyType.Unspecified;
            if (_parser.GetStringToEnumCurrency().ContainsKey(item.Extended.BaseType))
                currencyType = _parser.GetStringToEnumCurrency()[item.Extended.BaseType];
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
        public  Price GetRate(CurrencyType pay, CurrencyType get)
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
        public static Dictionary<CurrencyType, List<Price>> ExchangeTable = new Dictionary<CurrencyType, List<Price>>();
    }
}
