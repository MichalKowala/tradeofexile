using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.DTOs
{
    public class PriceDTO : BaseDTO
    {
        public double Ammount { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public Uri IconLink { get; set; }
    }
}
