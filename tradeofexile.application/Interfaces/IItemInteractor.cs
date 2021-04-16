using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.DTOs;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Abstraction
{
    public interface IItemInteractor
    {
        public List<ItemDTO> GetUniquesToCache(ItemCategory itemCategory);
    }
}
