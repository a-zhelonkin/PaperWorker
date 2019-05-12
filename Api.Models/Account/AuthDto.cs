using Newtonsoft.Json;

namespace Api.Models.Account
{
    public class AuthDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}