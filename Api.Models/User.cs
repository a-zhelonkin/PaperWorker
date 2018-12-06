using Api.Models.Base;
using Newtonsoft.Json;

namespace Api.Models
{
    public class User : Entity
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}