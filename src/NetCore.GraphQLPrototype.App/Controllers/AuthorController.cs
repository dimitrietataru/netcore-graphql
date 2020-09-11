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
    public sealed class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;
        private readonly IBookService bookService;

        public AuthorController(IAuthorService authorService, IBookService bookService)
        {
            this.authorService = authorService;
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("api/v1/authors")]
        [ProducesResponseType(typeof(IEnumerable<Author>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            var authors = await authorService.GetAuthorsAsync();

            return Ok(authors);
        }

        [HttpGet]
        [Route("api/v1/authors/{authorId:int}")]
        [ProducesResponseType(typeof(Author), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAuthorByIdAsync(int authorId)
        {
            var author = await authorService.GetAuthorByIdAsync(authorId);

            return Ok(author);
        }

        [HttpGet]
        [Route("api/v1/authors/{authorId:int}/books")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBooksByAuthorIdAsync(int authorId)
        {
            var books = await bookService.GetBooksByAuthorIdAsync(authorId);

            return Ok(books);
        }
    }
}
