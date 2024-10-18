
using System.Text.Json.Serialization;

namespace caserandomuser.Models
{
    public class EstruturaApiResponse
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("name")]
        public NameResponse Name { get; set; }

        [JsonPropertyName("location")]
        public LocationResponse Location { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("login")]
        public LoginResponse Login { get; set; }

        [JsonPropertyName("dob")]
        public DobResponse Dob { get; set; }

        [JsonPropertyName("registered")]
        public RegisteredResponse Registered { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("cell")]
        public string Cell { get; set; }

        [JsonPropertyName("id")]
        public IdResponse Id { get; set; }

        [JsonPropertyName("picture")]
        public PictureResponse Picture { get; set; }

        [JsonPropertyName("nat")]
        public string Nat { get; set; }
   }
}