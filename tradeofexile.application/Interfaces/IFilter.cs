using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Interfaces
{
    public interface IFilter
    {
        public List<Stash> ApplyAllFilters(List<Stash> stashes);
        public List<Stash> RemoveEmptyStashes(List<Stash> stashes);
        public List<Stash> RemoveStandardLeagueStashes(List<Stash> stashes);
        public List<Stash> RemoveItemsWithNoPrice(List<Stash> stashes);
    }
}
