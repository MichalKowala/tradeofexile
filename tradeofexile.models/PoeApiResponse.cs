using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models
{
    public class PoeApiResponse
    {
        [JsonProperty("next_change_id")]
        public string Next_Change_Id;
        [JsonProperty("stashes")]
        public List<Stash> Stashes;
    }
}
