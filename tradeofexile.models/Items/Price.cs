using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models.Items
{
    public struct Price
    {
       public double Ammount;
       public CurrencyType CurrencyType;
        public Price(double ammount, CurrencyType currencyType)
        {
            Ammount = ammount;
            CurrencyType = currencyType;
        }
    }
}
