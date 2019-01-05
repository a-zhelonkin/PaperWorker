using System;
using Newtonsoft.Json;

namespace Api.Models.Base
{
    public abstract class EntityDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}