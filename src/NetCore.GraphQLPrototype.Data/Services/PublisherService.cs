using NetCore.GraphQLPrototype.Data.Entities;
using NetCore.GraphQLPrototype.Data.Repositories.Interfaces;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Services
{
    public sealed class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            return await publisherRepository.GetPublishersAsync();
        }

        public async Task<Publisher> GetPublisherByIdAsync(int publisherId)
        {
            if (publisherId == default)
            {
                throw new ArgumentNullException(nameof(publisherId));
            }

            return await publisherRepository.GetPublisherByIdAsync(publisherId);
        }
    }
}
