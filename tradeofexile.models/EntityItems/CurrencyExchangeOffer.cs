using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.models.EntityItems
{
    public class CurrencyExchangeOffer : BaseEntity
    {
        public CurrencyType FromCurrency { get; set; }
        public CurrencyType ToCurrency { get; set; }
        public double Rate { get; set; }
    }
}
