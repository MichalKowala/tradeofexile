using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models
{
    public class ResponseStash
    {
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("public")]
        public bool IsPublic;
        [JsonProperty("accountName")]
        public string AccountName;
        [JsonProperty("lastCharacterName")]
        public string LastCharacterName;
        [JsonProperty("stash")]
        public string StashName;
        [JsonProperty("stashType")]
        public string StashType;
        [JsonProperty("league")]
        public string League;
        [JsonProperty("items")]
        public List<ResponseItem> Items;

    }
}
