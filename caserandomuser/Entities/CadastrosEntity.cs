
using System.ComponentModel.DataAnnotations;

namespace caserandomuser.Entities
{
    public class CadastrosEntity
    {   
        [Key]
        public int IdInt { get; set; }
        public string Gender { get; set; }

        public int NameEntityId { get; set; }
        public NameEntity Name { get; set; }

        public int LocationEntityId { get; set; }
        public LocationEntity Location { get; set; }
        
        public string Email { get; set; }
        
        public int LoginEntityId { get; set; }
        public LoginEntity Login { get; set; }

        public int DobEntityId { get; set; }
        public DobEntity Dob { get; set; }

        public int RegisteredEntityId { get; set; }
        public RegisteredEntity Registered { get; set; }

        public string Phone { get; set; }
        public string Cell { get; set; }

        public int IdEntityId { get; set; }
        public IdEntity Id { get; set; }

        public int PictureEntityId { get; set; }
        public PictureEntity Picture { get; set; }
        
        public string Nat { get; set; }
    }
}