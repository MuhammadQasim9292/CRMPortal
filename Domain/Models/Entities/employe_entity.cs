using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.BaseEntitiyModels;

namespace Domain.Models.Entities
{
    public class EmployeeJobDescription : BasicEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Required]
        public int DesignationId { get; set; }
    }
}
