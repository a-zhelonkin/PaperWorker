using Api.Models.Base;
using Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Models.Account
{
    public class RoleDto : EntityDto
    {
        [JsonProperty("name")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleName Name { get; set; }
    }
}