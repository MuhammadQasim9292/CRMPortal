using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Entities;
using Domain.Models.BaseEntities;

namespace Domain.Models.Entities
{
    public class Book:BaseEntities.BaseEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Author { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(13)")]
        public string ISBN { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }


    }
}
