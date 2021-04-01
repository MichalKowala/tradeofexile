using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.Interfaces;
using tradeofexile.models;
using tradeofexile.models.EntityItems;

namespace tradeofexile.infrastructure
{
    public  class Filter : IFilter
    {
        public  List<Stash> ApplyAllFilters(List<Stash> stashes)
        {
            stashes = RemovePrivateStashes(stashes);
            stashes = RemoveEmptyStashes(stashes);
           // stashes = RemoveStandardLeagueStashes(stashes);
            stashes = RemoveItemsWithNoPrice(stashes);
            return stashes;
        }
        public List<Stash> RemovePrivateStashes(List<Stash> stashes)
        {
            stashes.RemoveAll(x => x.IsPublic == false);
            return stashes;
        }
        public  List<Stash> RemoveEmptyStashes(List<Stash> stashes)
        {
            stashes.RemoveAll(x => x.Items.Count == 0 || x.AccountName == null);
            return stashes;
        }
        public  List<Stash> RemoveStandardLeagueStashes(List<Stash> stashes)
        {
            stashes.RemoveAll(x => x.League == LeagueType.Standard);
            return stashes;
        }
        public  List<Stash> RemoveItemsWithNoPrice(List<Stash> stashes)
        {
            foreach (Stash s in stashes)
            {
                s.Items.RemoveAll(x => x.Price==null);
            }
            return stashes;
        }
    }
}