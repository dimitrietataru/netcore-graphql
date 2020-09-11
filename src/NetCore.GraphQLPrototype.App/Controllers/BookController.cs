using Microsoft.AspNetCore.Mvc;
using NetCore.GraphQLPrototype.Data.Entities;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.App.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public sealed class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("api/v1/books")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = await bookService.GetBooksAsync();

            return Ok(books);
        }

        [HttpGet]
        [Route("api/v1/books/{isbn}")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBookByIsbnAsync(string isbn)
        {
            var book = await bookService.GetBookByIsbnAsync(isbn);

            return Ok(book);
        }
    }
}
