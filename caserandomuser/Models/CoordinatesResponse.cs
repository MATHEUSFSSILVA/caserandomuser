
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class CoordinatesResponse
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}