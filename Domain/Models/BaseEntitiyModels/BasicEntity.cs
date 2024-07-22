using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BaseEntitiyModels
{
    public class BasicEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public string  AddedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
        public DateTime UpdatedDate { get; set; }
    }
  
}
