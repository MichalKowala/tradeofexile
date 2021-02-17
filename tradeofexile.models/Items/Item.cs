using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tradeofexile.models
{
    public class Item
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
        public List<Socket> Sockets;
        [JsonProperty("properties")]
        public List<Property> Properties;
        [JsonProperty("requirements")]
        public List<Requirement> Requirements;
        [JsonProperty("explicitMods")]
        public List<string> ExplicitMods;
        [JsonProperty("flavourText")]
        public List<string> FlavourText;
        [JsonProperty("frameType")]
        public int FrameType;
        [JsonProperty("extended")]
        public Extended Extended;
        [JsonProperty("x")]
        public int X;
        [JsonProperty("y")]
        public int Y;
        [JsonProperty("socketedItems")]
        public List<Item> SocketedItems;
        [JsonProperty("intentoryId")]
        public string InventoryId;
    }
}
