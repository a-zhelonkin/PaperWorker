using System;
using Newtonsoft.Json;

namespace Api.Models.Account
{
    public class LocalityDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("territoryId")]
        public Guid TerritoryId { get; set; }

        [JsonProperty("streets")]
        public StreetDto[] Streets { get; set; }
    }
}