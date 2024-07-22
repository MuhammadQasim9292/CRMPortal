using Application;
using Application.DTMs;
using Common.Constants;
using Common.Responses;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_With_CleanArchitecture.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookService;
        public BookController(IBook bookService)
        {
           
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("GetBookById/{id}")]
        public async Task<ActionResult<ResponseVm>> GetBookbyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var book = await _bookService.GetBookbyId(id);
            return Ok(book);
        }

        [HttpPost("AddBook")]
        public async Task<ActionResult<ResponseVm>> AddBook([FromBody] AddBookDTM book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _bookService.AddBook(book);
            return Ok(response);
        }
        [HttpPost("UpdateBook/{id}")]
        public async Task<ActionResult<ResponseVm>> UpdateBook(int id, [FromBody] UpdateBookDtm book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _bookService.UpdateBook(id, book);
            return Ok(response);
        }
        [HttpPost("DeleteBook/{id}")]
        public async Task<ActionResult<ResponseVm>> DeleteBook(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _bookService.DeleteBook(id);
            return Ok(response);
        }

    }
}
