using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models.Items
{
    public class Item
    {
        public string Name;        
        public Uri IconLink;
        public LeagueType League;
        public string Id;
        public Extended Extended = new Extended();
        public Price Price;
    }
}
