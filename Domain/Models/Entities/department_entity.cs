using System;
using Domain.Models.BaseEntities;

namespace Domain.Models.Entities
{
    public class DepartmentEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
