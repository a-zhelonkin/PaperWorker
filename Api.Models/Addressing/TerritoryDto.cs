using System;
using Newtonsoft.Json;

namespace Api.Models.Account
{
    public class TerritoryDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentId")]
        public Guid? ParentId { get; set; }

        [JsonProperty("localities")]
        public LocalityDto[] Localities { get; set; }

        [JsonProperty("children")]
        public TerritoryDto[] Children { get; set; }
    }
}