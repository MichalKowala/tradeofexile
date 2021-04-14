using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.Interfaces
{
    public interface IItemsService
    {
        public List<ItemModel> GetCachedItems(string cacheKey, LeagueType leagueType, ItemCategory itemCategory);
        public void CacheItems(string cacheKey, ItemCategory category);
    }
}
