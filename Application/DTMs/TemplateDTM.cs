using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs
{
    public record TemplateDTM
    (
        int LetterTypeId,
        string Template,
        string LetterName
    );
}
