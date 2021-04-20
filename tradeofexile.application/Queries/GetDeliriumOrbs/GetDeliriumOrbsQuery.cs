using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.DTOs;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Queries.GetDeliriumOrbs
{
    public class GetDeliriumOrbsQuery : IRequest<List<ItemDTO>>
    {
        public LeagueType LeagueType { get; set; }
        public string CacheKey { get; set; }
        public GetDeliriumOrbsQuery(LeagueType leagueType, string cacheKey)
        {
            LeagueType = leagueType;
            CacheKey = cacheKey;
        }
    }
}
