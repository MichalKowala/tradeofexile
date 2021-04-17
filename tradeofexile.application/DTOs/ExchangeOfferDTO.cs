using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.DTOs
{
    public class ExchangeOfferDTO
    {
        public CurrencyType CurrencyType { get; set; }
        public Uri IconLink { get; set; } 
        public CurrencyType BuyType { get; set; }
        public double BuyRate { get; set; }
        public Uri BuyIconLink { get; set; }
        public CurrencyType SellType { get; set; }
        public double SellRate { get; set; }
        public Uri SellIconLink { get; set; } 

    }
}
