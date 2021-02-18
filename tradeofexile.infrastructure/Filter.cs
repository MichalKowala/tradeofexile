using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models;

namespace tradeofexile.infrastructure
{
    public static class Filter
    {
        public static List<Stash> ApplyAllFilters(List<Stash> stashes)
        {
            stashes = RemoveEmptyStashes(stashes);
            stashes = RemoveStandardLeagueStashes(stashes);
            stashes = RemoveItemsWithNoPrice(stashes);
            stashes = RemoveEmptyStashes(stashes);
            return stashes;
        }
        public static List<Stash> RemoveEmptyStashes (List<Stash> stashes)
        {
            stashes.RemoveAll(x => x.Items.Count == 0 || x.AccountName == null);
            return stashes;
        }
        public static List<Stash> RemoveStandardLeagueStashes (List<Stash> stashes)
        {
            stashes.RemoveAll(x => x.League == "Standard");
            return stashes;
        }
        public static List<Stash> RemoveItemsWithNoPrice (List<Stash> stashes)
        {
            foreach(Stash s in stashes)
            {
                s.Items.RemoveAll(x => x.Price == null);
            }
            return stashes;
        }
    }
}
