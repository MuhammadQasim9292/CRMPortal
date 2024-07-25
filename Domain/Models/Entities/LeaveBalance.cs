using Domain.Models.BaseEntitiyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class LeaveBalance : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public decimal Balance { get; set; }
        public string UpdatedBy { get; set; } // This should not be NULL
        public decimal Availed { get; set; }
        public int FYId { get; set; }
    }

}
