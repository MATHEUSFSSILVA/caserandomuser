
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class StreetResponse
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}