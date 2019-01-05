using Core;
using Newtonsoft.Json;

namespace Api.Models
{
    public class InviteDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("roles")]
        public RoleName[] Roles { get; set; }
    }
}