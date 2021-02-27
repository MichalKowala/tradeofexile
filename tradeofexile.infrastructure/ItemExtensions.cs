using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tradeofexile.models;
using tradeofexile.models.Enums;

namespace tradeofexile.infrastructure
{
    public static class ItemExtensions
    {
        public static List<string> GetListOfUniqueItemsByClass(GamepediaItemClass itemClass)
        {
            List<string> listOfItems = new List<string>();
            string gamepediaCallUrl = ApiItemQuerier.GetItemAndRarityParametriziedGamepediaCallUrl(itemClass, ItemRarity.Unique, ResponseFormat.json);
            string response = ApiHelper.GetResponseFromApi(gamepediaCallUrl + "&format=json");
            JObject jObject = JObject.Parse(response);
            foreach (JToken t in jObject["cargoquery"])
            {
                JToken token = t.Value<JToken>("title");
                listOfItems.Add(token.Value<string>("name"));
            }
            return listOfItems;
        }
        public static List<string> GetListOfCurrencyItems()
        {
            List<string> listOfItems = new List<string>();
            string poeWatchCallUrl = "https://api.poe.watch/get?category=currency&league=Ritual";
            string response = ApiHelper.GetResponseFromApi(poeWatchCallUrl);
            JArray jArray = JArray.Parse(response);
            foreach (JToken t in jArray)
            {
                listOfItems.Add(t.Value<string>("name"));
            }
            return listOfItems;
        }
    }
}
