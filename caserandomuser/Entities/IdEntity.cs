
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class IdEntity
    {
        [Key]
        public int IdInt { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}