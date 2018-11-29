using Api.Models.Base;
using Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Models
{
    public class Role : Entity
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleName Name { get; set; }
    }
}