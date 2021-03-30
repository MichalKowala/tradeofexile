using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.MappingProfiles
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<Price, PriceModel>();
        }
    }
}
