using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTMs.Search;
using Common.Responses;

namespace Application.Interfaces
{
    public  interface ISearch
    {
        Task<ResponseVm> GetSearchtext(string SearchText);
    }
}
