using NetCore.GraphQLPrototype.Data.Entities;
using NetCore.GraphQLPrototype.Data.Repositories.Interfaces;
using NetCore.GraphQLPrototype.Data.Repositories.Seed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Repositories
{
    public sealed class BookRepository : IBookRepository
    {
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await Task.FromResult(
                SeedData.Books.AsEnumerable());
        }

        public async Task<Book> GetBookByIsbnAsync(string isbn)
        {
            return await Task.FromResult(
                SeedData.Books.FirstOrDefault(book => book.Isbn.Equals(isbn)));
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await Task.FromResult(
                SeedData.Books.Where(book => book.Author.Id.Equals(authorId)));
        }

        public async Task<IEnumerable<Book>> GetBooksByPublisherIdAsync(int publisherId)
        {
            return await Task.FromResult(
                SeedData.Books.Where(book => book.Publisher.Id.Equals(publisherId)));
        }
    }
}
