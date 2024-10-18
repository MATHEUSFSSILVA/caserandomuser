
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class StreetEntity
    {
        [Key]
        public int IdInt { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
    }
}