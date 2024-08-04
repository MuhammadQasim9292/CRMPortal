using Domain.Models.BaseEntitiyModels;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Template : Template_base_entities
    {
        public int ID { get; set; }
        public int LetterTypeId { get; set; }
        public string template{ get; set; }
        public string LetterName { get; set; }
        
    }
}
