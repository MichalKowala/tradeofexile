using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.models.Items
{
    public class Stash : BaseEntity
    {
        public bool IsPublic;
        public string AccountName;
        public LeagueType League;
        public List<Item> Items;
    }
}
