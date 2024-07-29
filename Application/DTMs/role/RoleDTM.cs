using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs.role
{
    public record RoleDTM
(
    //long role_id,
    string role_Name,
      string role_Description,
        bool role_IsActive
    );
}
