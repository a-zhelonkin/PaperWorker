using System;
using Newtonsoft.Json;

namespace Api.Models.Account
{
    public class StructureDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("alone")]
        public bool Alone { get; set; }

        [JsonProperty("streetId")]
        public Guid StreetId { get; set; }

        [JsonProperty("addresses")]
        public AddressDto[] Addresses { get; set; }
    }
}