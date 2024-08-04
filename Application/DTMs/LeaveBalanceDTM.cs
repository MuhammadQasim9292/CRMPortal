using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs
{
    namespace Application.DTMs
    {
        public record LeaveBalanceDTM(
            int EmployeeId,
            int LeaveTypeId,
            decimal Balance,
            decimal Availed,
            int FYId);
    }

}
