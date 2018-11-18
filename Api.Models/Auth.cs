using Newtonsoft.Json;

namespace Api.Models
{
    public class Auth
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}