using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Enums;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application.Abstraction
{
    public interface IGamepediaResponseHandler
    {
        public List<string> GetUniqueNames(GamepediaItemClass itemClass);
        public List<string> GetUniqueNames(ItemCategory itemCategory);
        public List<string> GetListOfCurrencyItems();
        public void UpdateUniqueNames();
    }
}
