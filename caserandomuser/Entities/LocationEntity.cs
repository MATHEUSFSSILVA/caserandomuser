
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class LocationEntity
    {   
        [Key]
        public int IdInt { get; set; }

        public int StreetEntityId { get; set; }
        public StreetEntity Street { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Postcode { get; set; }

        public int CoordinatesEntityId { get; set; }
        public CoordinatesEntity Coordinates { get; set; }
        
        public int TimezoneEntityId { get; set; }
        public TimezoneEntity Timezone { get; set; }
    }
}