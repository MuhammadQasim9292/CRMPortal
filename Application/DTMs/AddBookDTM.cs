using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTMs
{
    public record AddBookDTM
    (
        string Title,
        string Author,
        string Description,
        string ISBN,
        string ImageUrl,
        decimal Price
        
        );
}
