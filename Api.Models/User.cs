using Api.Models.Base;
using Newtonsoft.Json;

namespace Api.Models
{
    public class User : Entity
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}