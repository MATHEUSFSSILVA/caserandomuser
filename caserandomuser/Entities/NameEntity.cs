
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class NameEntity
    {   
        [Key]
        public int IdInt { get; set; }
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}