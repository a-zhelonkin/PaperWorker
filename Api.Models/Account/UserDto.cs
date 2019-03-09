using System;
using Api.Models.Base;
using Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Models
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

        [JsonProperty("birthDateTime")]
        public DateTime? BirthDateTime { get; set; }

        [JsonProperty("employmentDateTime")]
        public DateTime? EmploymentDateTime { get; set; }
    }
}