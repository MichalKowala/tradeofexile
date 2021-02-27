using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models.Items
{
    public class Stash
    {
        public string Id;
        public bool IsPublic;
        public string AccountName;
        public LeagueType League;
        public List<Item> Items;
    }
}
