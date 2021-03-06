﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.application.DTOs;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Interfaces
{
    public interface IUniquesService
    {
        public List<ItemDTO> GetCachedUniques(string cacheKey, LeagueType leagueType, ItemCategory itemCategory);
        public void CacheUniques(string cacheKey, ItemCategory category);
    }
}
