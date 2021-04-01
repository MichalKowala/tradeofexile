using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.models.EntityItems
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public Uri IconLink { get; set; }
        public LeagueType League { get; set; }
        public  Extended Extended { get; set; }
        public string ResponseId { get; set; }
        public virtual Price Price { get; set; }
    }
}
