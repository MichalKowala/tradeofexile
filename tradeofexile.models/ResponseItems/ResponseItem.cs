using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models
{
    public class ResponseItem
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("verified")]
        public bool IsVerified;
        [JsonProperty("w")]
        public int Width;
        [JsonProperty("h")]
        public int Height;
        [JsonProperty("icon")]
        public Uri IconLink;
        [JsonProperty("league")]
        public string League;
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("sockets")]
        public List<ResponseSocket> Sockets;
        [JsonProperty("properties")]
        public List<ResponseProperty> Properties;
        [JsonProperty("requirements")]
        public List<ResponseRequirement> Requirements;
        [JsonProperty("explicitMods")]
        public List<string> ExplicitMods;
        [JsonProperty("flavourText")]
        public List<string> FlavourText;
        [JsonProperty("frameType")]
        public int FrameType;
        [JsonProperty("extended")]
        public ResponseExtended Extended;
        [JsonProperty("x")]
        public int X;
        [JsonProperty("y")]
        public int Y;
        [JsonProperty("socketedItems")]
        public List<ResponseItem> SocketedItems;
        [JsonProperty("intentoryId")]
        public string InventoryId;
        [JsonProperty("note")]
        public string Price;
    }
}
