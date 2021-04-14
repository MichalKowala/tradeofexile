using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.models.EntityItems;

namespace tradeofexile.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public PriceModel Price { get; set; }
        public List<PriceModel> OtherCurrencyPrices { get; set; } = new List<PriceModel>();
        public Uri IconLink { get; set; }
        public LeagueType League { get; set; }
        public double SevenDaysChange { get; set; }
        public int Occurances { get; set; } = 1;
    }
}
