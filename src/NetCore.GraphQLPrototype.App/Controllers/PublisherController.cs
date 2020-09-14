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
    public sealed class PublisherController : ControllerBase
    {
        private readonly IAuthorService authorService;
        private readonly IBookService bookService;
        private readonly IPublisherService publisherService;

        public PublisherController(
            IAuthorService authorService,
            IBookService bookService,
            IPublisherService publisherService)
        {
            this.authorService = authorService;
            this.bookService = bookService;
            this.publisherService = publisherService;
        }

        [HttpGet]
        [Route("api/v1/publishers")]
        [ProducesResponseType(typeof(IEnumerable<Publisher>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPublishersAsync()
        {
            var publishers = await publisherService.GetPublishersAsync();

            return Ok(publishers);
        }

        [HttpGet]
        [Route("api/v1/publishers/{publisherId:int}")]
        [ProducesResponseType(typeof(Author), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPublisherByIdAsync(int publisherId)
        {
            var publisher = await publisherService.GetPublisherByIdAsync(publisherId);

            return Ok(publisher);
        }

        [HttpGet]
        [Route("api/v1/publishers/{publisherId:int}/authors")]
        [ProducesResponseType(typeof(IEnumerable<Author>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAuthorsByPublisherIdAsync(int publisherId)
        {
            var authors = await authorService.GetAuthorsByPublisherIdAsync(publisherId);

            return Ok(authors);
        }

        [HttpGet]
        [Route("api/v1/publishers/{publisherId:int}/books")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBooksByPublisherIdAsync(int publisherId)
        {
            var books = await bookService.GetBooksByPublisherIdAsync(publisherId);

            return Ok(books);
        }
    }
}
