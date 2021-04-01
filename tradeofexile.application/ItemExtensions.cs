using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using tradeofexile.application.Abstraction;
using tradeofexile.models.Enums;
using tradeofexile.models.EntityItems;

namespace tradeofexile.infrastructure
{
    public  class ItemExtensions : IItemExtensions
    {
        private readonly IApiItemQuerier _apiItemQuerier;
        private readonly IApiHelper _apiHelper;
        private readonly IParser _parser;
        public ItemExtensions(IApiItemQuerier apiItemQuerier, IApiHelper apiHelper, IParser parser)
        {
            _apiItemQuerier = apiItemQuerier;
            _apiHelper = apiHelper;
            _parser = parser;
        }
        public  List<string> GetNamesOfUniquesByGamepediaItemClass(GamepediaItemClass itemClass)
        {
            List<string> names = new List<string>();
            string gamepediaCallUrl = _apiItemQuerier.GetItemAndRarityParametriziedGamepediaCallUrl(itemClass, ItemRarity.Unique, ResponseFormat.json);
            string response = _apiHelper.GetResponseFromApi(gamepediaCallUrl + "&format=json");
            JObject jObject = JObject.Parse(response);
            foreach (JToken t in jObject["cargoquery"])
            {
                JToken token = t.Value<JToken>("title");
                names.Add(token.Value<string>("name"));
            }
            return names;
        }
        public  List<string> GetNamesOfUniquesByItemCategory(ItemCategory itemCategory)
        {
            List<string> names = new List<string>();
            List<GamepediaItemClass> itemClasses = _parser.GetItemCategorytoGamediaItemClassDictionary()[itemCategory]; 
            foreach (GamepediaItemClass itemClass in itemClasses)
            {
                names.AddRange(GetNamesOfUniquesByGamepediaItemClass(itemClass));
            }
            return names;
        }
        public  List<string> GetListOfCurrencyItems()
        {
            List<string> listOfItems = new List<string>();
            string poeWatchCallUrl = "https://api.poe.watch/get?category=currency&league=Ritual";
            string response = _apiHelper.GetResponseFromApi(poeWatchCallUrl);
            JArray jArray = JArray.Parse(response);
            foreach (JToken t in jArray)
            {
                listOfItems.Add(t.Value<string>("name"));
            }
            return listOfItems;
        }
    }
}
