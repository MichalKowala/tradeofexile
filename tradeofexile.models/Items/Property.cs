using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace tradeofexile.models
{
    public class Property
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("displayMode")]
        public int DisplayMode;
        [JsonProperty("type")]
        public int Type;
        [JsonProperty("values")]
        public List<List<string>> Values;
    }
}