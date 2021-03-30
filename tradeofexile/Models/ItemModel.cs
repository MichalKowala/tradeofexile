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
        public Uri IconLink { get; set; }
    }
}
