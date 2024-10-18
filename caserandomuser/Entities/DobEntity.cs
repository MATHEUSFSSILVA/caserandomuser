
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class DobEntity
    {   
        [Key]
        public int IdInt { get; set; }
        public DateTime Date { get; set; }
        public string Age { get; set; }
    }
}