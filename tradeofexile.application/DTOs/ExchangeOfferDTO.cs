using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.DTOs
{
    public class ExchangeOfferDTO
    {
        public CurrencyType CurrencyType { get; set; }
        public CurrencyType BuyType { get; set; }
        public double BuyRate { get; set; }
        public CurrencyType SellType { get; set; }
        public double SellRate { get; set; }
        
    }
}
