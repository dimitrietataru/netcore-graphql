﻿using NetCore.GraphQLPrototype.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIsbnAsync(string isbn);
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
        Task<IEnumerable<Book>> GetBooksByPublisherIdAsync(int publisherId);
    }
}
