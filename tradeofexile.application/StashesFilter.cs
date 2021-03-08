using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models;

namespace tradeofexile.infrastructure
{
    public static class StashesFilter
    {
        public static List<ResponseStash> ApplyAllFilters(List<ResponseStash> stashes)
        {
            stashes = RemoveEmptyStashes(stashes);
            stashes = RemoveStandardLeagueStashes(stashes);
            stashes = RemoveItemsWithNoPrice(stashes);
            stashes = RemoveEmptyStashes(stashes);
            return stashes;
        }
        public static List<ResponseStash> RemoveEmptyStashes (List<ResponseStash> stashes)
        {
            stashes.RemoveAll(x => x.Items.Count == 0 || x.AccountName == null);
            return stashes;
        }
        public static List<ResponseStash> RemoveStandardLeagueStashes (List<ResponseStash> stashes)
        {
            stashes.RemoveAll(x => x.League == "Standard");
            return stashes;
        }
        public static List<ResponseStash> RemoveItemsWithNoPrice (List<ResponseStash> stashes)
        {
            foreach(ResponseStash s in stashes)
            {
                if (s.StashName.StartsWith("~price"))
                    foreach (ResponseItem i in s.Items)
                        i.Price = s.StashName;
                else
                s.Items.RemoveAll(x => x.Price == null);
            }
            return stashes;
        }
    }
}
