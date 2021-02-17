using Newtonsoft.Json;

namespace tradeofexile.models
{
    public class Socket
    {
        [JsonProperty("group")]
        public string Group;
        [JsonProperty("attr")]
        public string Attribute;
        [JsonProperty("sColour")]
        public string Colour;
    }
}