using NetCore.GraphQLPrototype.Data.Entities;
using NetCore.GraphQLPrototype.Data.Repositories.Interfaces;
using NetCore.GraphQLPrototype.Data.Repositories.Seed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Repositories
{
    public sealed class AuthorRepository : IAuthorRepository
    {
        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await Task.FromResult(
                SeedData.Authors.AsEnumerable());
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            return await Task.FromResult(
                SeedData.Authors.FirstOrDefault(author => author.Id.Equals(authorId)));
        }

        public async Task<IEnumerable<Author>> GetAuthorsByPublisherIdAsync(int publisherId)
        {
            return await Task.FromResult(
                SeedData.Authors.Where(author => author.Publishers.Any(id => id.Equals(publisherId))));
        }
    }
}
