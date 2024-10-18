
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class CoordinatesEntity
    {
        [Key]
        public int IdInt { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}