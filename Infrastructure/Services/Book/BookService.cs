
﻿using Infrastructure.Context;
using Domain.Models.Entities;

//﻿using Application.Interfaces;
//using Infrastructure.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Domain.Models.Entities;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Azure;

using Common.Responses;
using Common.Constants;
using Common.CommonMethods;
using Microsoft.EntityFrameworkCore;
using Application.DTMs;
using Application.Interfaces;
using Application;
using Microsoft.Data.SqlClient;
using Dapper;
using Common.Token;

namespace Infrastructure
{
    public class BookService : IBook
    {
        private readonly Database_context _context;
        public BookService(Database_context db)
        {

            _context = db;
        }
        public async Task<ResponseVm> AddBook(AddBookDTM book)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var IsBookExist = _context.Books.FirstOrDefault(x => x.ISBN == book.ISBN);
            var addedbook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                ISBN = book.ISBN,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                //CategoryId = book.CategoryId
            };

            if (IsBookExist == null)
            {

                _context.Books.Add(addedbook);
                await _context.SaveChangesAsync();
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Book Added Successfully";
                response.ResponseData = book;


            }
            else
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Book Already Exist";
                response.ResponseData = null;

            }
            return response;
        }

        public async Task<ResponseVm> DeleteBook(int id)
        {
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            string tablename = Tables.Book_Table;
            var isDeleted = await CommonOpertions.SoftDelete(CommonOpertions.GetConnectionString(), tablename, id);
            if (isDeleted == false)
            {
                response.ResponseCode = Responses.BadRequestCode;
                response.ResponseMessage = "Unable to delete book";

            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Successfully deleted books";
                response.ResponseData = isDeleted;
            }
            return response;

        }

        public async Task<IEnumerable<dynamic>> GetAllBooks()
        {
            string query = "SELECT b.Id , b.Title ,b.Author ,b.Description,b.ISBN ,b.ImageUrl ,b.Price FROM Books b ";
            using (var connection = new SqlConnection(CommonOpertions.GetConnectionString()))
            {
                var books = await connection.QueryAsync<dynamic>(query);
                var allBooks = books.ToList();
                return allBooks;
            }

        }

        public async Task<ResponseVm> GetBookbyId(int id)
        {
             ResponseVm response = ResponseVm.GetResponseVmInstance;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var book =await CommonOpertions.ExecuteStoredProceduresList("SP_GetBookById", parameters, CommonOpertions.GetConnectionString());
            var bookData = book.ToList();
            if (bookData.Count == 0)
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Book not found";
                response.ResponseData = null;
            }
            else
            {
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Book found";
                response.ResponseData = bookData;
            }
            return response;
            
        }

       
        public async Task<ResponseVm> UpdateBook(int id, UpdateBookDtm book)
        {
            
            ResponseVm response = ResponseVm.GetResponseVmInstance;
            var IsExist = _context.Books.FirstOrDefault(x => x.Id == id);
            if (IsExist != null)
            {
               
                IsExist.Title = book.title;
                IsExist.Author = book.author;
                IsExist.Description = book.description;
                IsExist.ISBN = book.isbn;
                IsExist.ImageUrl = book.imageUrl;
                IsExist.Price = book.price;
                
                await _context.SaveChangesAsync();
                response.ResponseCode = Responses.SuccessCode;
                response.ResponseMessage = "Book Updated Successfully";
                response.ResponseData = book;
                   

            }
            else
            {
                response.ResponseCode = Responses.NotFoundCode;
                response.ResponseMessage = "Book not found";
                response.ResponseData = null;
            }

            return response;
        }
    }
}
