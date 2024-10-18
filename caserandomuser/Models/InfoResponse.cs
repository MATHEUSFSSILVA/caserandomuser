
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class InfoResponse
    {
        [JsonPropertyName("seed")]
        public string Seed { get; set; }

        [JsonPropertyName("results")]
        public string Results { get; set; }

        [JsonPropertyName("page")]
        public string Page { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}