using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BaseEntitiyModels
{
   public class Template_base_entities
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string LetterName { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
