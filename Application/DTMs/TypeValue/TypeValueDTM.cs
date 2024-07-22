using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs.TypeValue
{
    public record TypeValueDTM
  (
      int Type_Id,
      string Type_Value
      );
    public record TypeValueUpdateDTM
  (
        int TypeValue_Id,
      int Type_Id,
      string Type_Value
      );
}
