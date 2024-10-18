
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class ApiResponse
    {
        [JsonPropertyName("results")]
        public List<EstruturaApiResponse> Results { get; set; }

        [JsonPropertyName("info")]
        public InfoResponse Info { get; set; }
    }
}