using Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Models.Account
{
    public class AuthInfoDto
    {
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = "guest";

        [JsonProperty("roles", ItemConverterType = typeof(StringEnumConverter))]
        public RoleName[] Roles { get; set; } = { };
    }
}