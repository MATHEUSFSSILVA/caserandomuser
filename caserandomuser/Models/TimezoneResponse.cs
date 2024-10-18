
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class TimezoneResponse
    {
        [JsonPropertyName("offset")]
        public string Offset { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}