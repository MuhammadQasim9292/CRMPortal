using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs.TypeValue
{
    public record TypeValueDTM
  (
      long Type_Id,
      string Type_Value
      );
    public record TypeValueUpdateDTM
  (
        long TypeValue_Id,
      long Type_Id,
      string Type_Value
      );
}
