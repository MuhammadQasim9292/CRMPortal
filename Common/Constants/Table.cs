using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constants
{
    public class Table
        //for district
    {
        public const string PropertyId = "ID";
        public const string PropertyName = "Name";

        // Constants for LeaveBalance Table
        public const string LeaveBalanceTableName = "LeaveBalances";
        public const string LeaveBalanceId = "ID";
        public const string LeaveBalanceEmployeeId = "EmployeeId";
        public const string LeaveBalanceLeaveTypeId = "LeaveTypeId";
        public const string LeaveBalanceBalance = "Balance";
        public const string LeaveBalanceAvailed = "Availed";
        public const string LeaveBalanceFYId = "FYId";
        public const string LeaveBalanceIsDeleted = "IsDeleted";
        public const string LeaveBalanceAddedBy = "AddedBy";
        public const string LeaveBalanceAddedDate = "AddedDate";
        public const string LeaveBalanceUpdatedBy = "UpdatedBy";
        public const string LeaveBalanceUpdatedDate = "UpdatedDate";

        public static string Tables { get; set; }

        // You can add more table-specific constants here as needed
        //public static string Tables { get; set; }

    }
}

