using Api.Models.Base;
using Newtonsoft.Json;

namespace Api.Models
{
    public class UserDto : EntityDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}