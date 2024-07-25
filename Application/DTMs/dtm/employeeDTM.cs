using System;

namespace Application.DTMs.dtm
{
    public record EmployeeDTM
    (
        int Id,
        string Name,
        string Description,
        int DesignationId,
        bool IsActive,
        bool IsDeleted,
        string AddedBy,
        DateTime AddedDate,
        string UpdatedBy,
        DateTime? UpdatedDate
    );
}
