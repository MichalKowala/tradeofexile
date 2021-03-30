using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tradeofexile.models.EntityItems;
using tradeofexile.Models;

namespace tradeofexile.MappingProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemModel>();
        }
    }
}
