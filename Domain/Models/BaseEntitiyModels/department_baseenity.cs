using System;

namespace Domain.Models.BaseEntities
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
