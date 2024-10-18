
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class InfoResponse
    {
        [JsonPropertyName("seed")]
        public string Seed { get; set; }

        [JsonPropertyName("results")]
        public int Results { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}