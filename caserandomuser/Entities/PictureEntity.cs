
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class PictureEntity
    {
        [Key]
        public int IdInt { get; set; }
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }
}