using System;
using Newtonsoft.Json;

namespace Api.Models.Account
{
    public class StreetDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localityId")]
        public Guid LocalityId { get; set; }

        [JsonProperty("structures")]
        public StructureDto[] Structures { get; set; }
    }
}