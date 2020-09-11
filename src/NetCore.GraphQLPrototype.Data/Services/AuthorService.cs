using NetCore.GraphQLPrototype.Data.Entities;
using NetCore.GraphQLPrototype.Data.Repositories.Interfaces;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Services
{
    public sealed class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await authorRepository.GetAuthorsAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            if (authorId == default)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return await authorRepository.GetAuthorByIdAsync(authorId);
        }

        public async Task<IEnumerable<Author>> GetAuthorsByPublisherIdAsync(int publisherId)
        {
            if (publisherId == default)
            {
                throw new ArgumentNullException(nameof(publisherId));
            }

            return await authorRepository.GetAuthorsByPublisherIdAsync(publisherId);
        }
    }
}
