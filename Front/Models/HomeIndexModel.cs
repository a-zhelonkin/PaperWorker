using Newtonsoft.Json;

namespace Front.Models
{
    public class HomeIndexModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}