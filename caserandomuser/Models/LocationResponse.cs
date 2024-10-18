
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class LocationResponse
    {
        [JsonPropertyName("street")]
        public StreetResponse Street { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }

        [JsonPropertyName("coordinates")]
        public CoordinatesResponse Coordinates { get; set; }

        [JsonPropertyName("timezone")]
        public TimezoneResponse Timezone { get; set; }
    }
}