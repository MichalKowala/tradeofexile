using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Items;

namespace tradeofexile.application.Abstraction
{
    public interface IPricer
    {
        public  void AddOffer(CurrencyType pay, Price get);
        public  Price GetRate(CurrencyType pay, CurrencyType get);
    }
}
