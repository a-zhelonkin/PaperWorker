using Newtonsoft.Json;

namespace Api.Models
{
    public class Auth
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}