using NetCore.GraphQLPrototype.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<IEnumerable<Author>> GetAuthorsByPublisherIdAsync(int publisherId);
    }
}
