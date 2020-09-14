using NetCore.GraphQLPrototype.Data.Entities;
using NetCore.GraphQLPrototype.Data.Repositories.Interfaces;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Services
{
    public sealed class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await bookRepository.GetBooksAsync();
        }

        public async Task<Book> GetBookByIsbnAsync(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentNullException(nameof(isbn));
            }

            return await bookRepository.GetBookByIsbnAsync(isbn);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            if (authorId == default)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return await bookRepository.GetBooksByAuthorIdAsync(authorId);
        }

        public async Task<IEnumerable<Book>> GetBooksByPublisherIdAsync(int publisherId)
        {
            if (publisherId == default)
            {
                throw new ArgumentNullException(nameof(publisherId));
            }

            return await bookRepository.GetBooksByPublisherIdAsync(publisherId);
        }
    }
}
