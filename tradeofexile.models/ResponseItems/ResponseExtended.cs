﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models
{
    public class ResponseExtended
    {
        [JsonProperty("category")]
        public string Category;
        [JsonProperty("subcategories")]
        public List<string> Subcategories;
        [JsonProperty("baseType")]
        public string BaseType;
    }
}
