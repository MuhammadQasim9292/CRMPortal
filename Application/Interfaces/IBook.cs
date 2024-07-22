using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Interfaces;
using Common.Responses;
using Application.DTMs;
using Dapper;


// using for action result

namespace Application
{
    public interface IBook
    {

        Task<IEnumerable<dynamic>> GetAllBooks();
        Task<ResponseVm> GetBookbyId(int id);
        Task<ResponseVm> AddBook(AddBookDTM book);
        Task<ResponseVm> UpdateBook(int id, UpdateBookDtm book);
        Task<ResponseVm> DeleteBook(int id);

    }
}