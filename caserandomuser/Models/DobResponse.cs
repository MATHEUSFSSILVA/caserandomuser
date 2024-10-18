
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class DobResponse
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("age")]
        public string Age { get; set; }
    }
}