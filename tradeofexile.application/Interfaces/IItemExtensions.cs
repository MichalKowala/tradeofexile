using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Enums;
using tradeofexile.models.Items;

namespace tradeofexile.application.Abstraction
{
    public interface IItemExtensions
    {
        public List<string> GetNamesOfUniquesByGamepediaItemClass(GamepediaItemClass itemClass);
        public List<string> GetNamesOfUniquesByItemCategory(ItemCategory itemCategory);
        public List<string> GetListOfCurrencyItems();
    }
}
