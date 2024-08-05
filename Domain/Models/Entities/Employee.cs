using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.BaseEntitiyModels;

namespace Domain.Models.Entities
{
    public  class Employee:BasicEntity   
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeID { get; set; }
        public long BranchID { get; set; }
        public long DistrictID { get; set; }
        public long PositionID { get; set; }
        public long ReligionID { get; set; }
        public long ReferedID { get; set; }
        public long DepartmentID { get; set; }
        public long ReasonID { get; set; }
        public long GradeID { get; set; }
        //  public long Client { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string EmployeeType { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string EmployeeName{ get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public int ParentageType { get; set; } //
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string Parentage { get; set; } = "";  /// 
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string LastName { get; set; } = "";
        public bool IsEmailVerified { get; set; } = false;
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string Country { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string PhoneNumber { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string UserType { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string Gender { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(50)]
        public string EmployeeCNIC { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string MartialStatus { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string Bloodgroup { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]

        public string EmpEmail { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]

        public string OfficialEmail { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]

        public string EmpcontactNo { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string EmergencyNo { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string EmpAddress { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string EmpPermanentAddress { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public string ReferredBy{ get; set; }//
        public DateTime JoiningDate { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(25)]
        public int ProbationEnd { get; set; }//
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public DateTime CNICIssuance { get; set; }//
        public DateTime CNICExpiry { get; set; }
        public string DepartureReason { get; set; }
        public string CurrentStatus { get; set; }
        public long ReportsTo { get; set; }//
        public string OfficeLevel { get; set; }
        public int Shift { get; set; }//
        public bool IsActive { get; set; } = false;
        public DateTime LeaveDate { get; set; }
        public string EmpPic { get; set; }
  
 
     
        public string ProfileImage { get; set; } = "";
        public bool IsBlocked { get; set; } = false;
        public bool IsRejoin { get; set; } = false;
    }
}
