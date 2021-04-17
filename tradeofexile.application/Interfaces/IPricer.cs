using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Abstraction
{
    public interface IPricer
    {
        public  void AddOffer(CurrencyType pay, Price get, LeagueType league);
        public  Price GetRate(CurrencyType pay, CurrencyType get);
    }
}
