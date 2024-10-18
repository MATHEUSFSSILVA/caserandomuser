
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class IdResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}