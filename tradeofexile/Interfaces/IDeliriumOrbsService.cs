using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.DTOs;
using tradeofexile.models.EntityItems;

namespace tradeofexile.Interfaces
{
    public interface IDeliriumOrbsService
    {
        public List<ItemDTO> GetCachedDeliriumOrbs(string cacheKey, LeagueType leagueType);
        public void CacheDeliriumOrbs(string cacheKey);
    }
}
