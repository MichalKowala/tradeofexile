using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.models.Enums;

namespace tradeofexile.infrastructure
{
    public static class ItemExtensions
    {
        public static List<string> GetListOfUniqueItemsByClass(ItemClass itemClass)
        {
            string gamepediaCallUrl = ApiItemQuerier.GetItemAndRarityParametriziedGamepediaCallUrl(itemClass, ItemRarity.Unique, ResponseFormat.json);
            string response = ApiHelper.GetResponseFromApi(gamepediaCallUrl+"&format=json");
            List<string> listOfItems = new List<string>();
            JObject jObject = JObject.Parse(response);
            foreach (JToken t in jObject["cargoquery"])
            {
                JToken token = t.Value<JToken>("title");
                listOfItems.Add(token.Value<string>("name"));
            }
            return listOfItems;
        }
    }
}
