
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class PictureResponse
    
    {
        [JsonPropertyName("large")]
        public string Large { get; set; }

        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}