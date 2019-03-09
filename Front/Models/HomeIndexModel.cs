using Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Front.Models
{
    public class HomeIndexModel
    {
        [JsonProperty("email")]
        public string Email { get; set; } = "guest";

        [JsonProperty("roles", ItemConverterType = typeof(StringEnumConverter))]
        public RoleName[] Roles { get; set; }
    }
}