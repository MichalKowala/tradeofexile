using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.DTOs
{
    public class ItemDTO : BaseDTO
    {
   
            public string Name { get; set; }
            public PriceDTO Price { get; set; }
            public List<PriceDTO> OtherCurrencyPrices { get; set; } = new List<PriceDTO>();
            public Uri IconLink { get; set; }
            public LeagueType League { get; set; }
            public double SevenDaysChange { get; set; }
            public int Occurances { get; set; } = 1;
        
    }
}
