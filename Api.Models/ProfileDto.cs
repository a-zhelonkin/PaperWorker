using System;
using Newtonsoft.Json;

namespace Api.Models
{
    public class ProfileDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("birthDateTime")]
        public DateTime BirthDateTime { get; set; }

        [JsonProperty("employmentDateTime")]
        public DateTime EmploymentDateTime { get; set; }
    }
}