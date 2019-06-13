using System;
using Newtonsoft.Json;

namespace Api.Models.Account
{
    public class AddressDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("structureId")]
        public Guid StructureId { get; set; }
    }
}