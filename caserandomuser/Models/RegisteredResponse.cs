
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class RegisteredResponse
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("age")]
        public string Age { get; set; }
    }
}