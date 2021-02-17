using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace tradeofexile.models
{
    public class Requirement
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("values")]
        public List<List<string>> Values;
        [JsonProperty("displayMode")]
        public string DisplayMode;
    }
}