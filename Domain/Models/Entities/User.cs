using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities
{
    public class User: BaseEntities.BaseEntities 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; } 

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
    }
}