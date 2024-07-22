using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs
{
    public record UpdateBookDtm(
        string title,
               string author,
                      string description,
                             string isbn,
                                    string imageUrl,
                                           decimal price);
    
}
