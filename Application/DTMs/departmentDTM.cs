using System;

namespace Application.DTMs
{
    public record DepartmentDTM
    (
        int Id,
        string Name,
        bool IsActive,
        bool IsDeleted,
        string AddedBy,
        DateTime AddedDate,
        string UpdatedBy,
        DateTime? UpdatedDate
    );
}
