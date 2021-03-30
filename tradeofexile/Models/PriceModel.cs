using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.models.EntityItems;

namespace tradeofexile.Models
{
    public class PriceModel
    {
        public double Ammount { get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}
