
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class TimezoneEntity
    {
        [Key]
        public int IdInt { get; set; }
        public string Offset { get; set; }
        public string Description { get; set; }
    }
}