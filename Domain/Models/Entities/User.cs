using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Models.BaseEntitiyModels;

namespace Domain.Models.Entities
{
    public class User: BasicEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  long  Id { get; set; } 

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Role { get; set; }
        //public Role Role { get; set; }//You must update the functions related to it.
        // Navigation property to represent the one-to-many relationship with Order
    }
}
