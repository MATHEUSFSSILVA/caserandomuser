
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class RegisteredEntity
    {   
        [Key]
        public int IdInt { get; set; }
        public DateTime Date { get; set; }
        public string Age { get; set; }
    }
}