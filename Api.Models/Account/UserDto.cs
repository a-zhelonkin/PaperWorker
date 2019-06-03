using Api.Models.Base;
using Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Models.Account
{
    public class UserDto : EntityDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status")]
        public UserStatus Status { get; set; }

        [JsonProperty("roles", ItemConverterType = typeof(StringEnumConverter))]
        public RoleName[] Roles { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}