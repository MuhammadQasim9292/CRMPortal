﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.BaseEntitiyModels;

namespace Domain.Models.Entities
{
    public class TypeValue : BasicEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       [ForeignKey("Types")]
        public int TypeId { get; set; }
        public virtual Types Type { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Value { get; set; }

    }
}
