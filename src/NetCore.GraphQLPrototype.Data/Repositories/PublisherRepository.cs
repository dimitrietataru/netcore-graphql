using NetCore.GraphQLPrototype.Data.Entities;
using NetCore.GraphQLPrototype.Data.Repositories.Interfaces;
using NetCore.GraphQLPrototype.Data.Repositories.Seed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            return await Task.FromResult(
                SeedData.Publishers.AsEnumerable());
        }

        public async Task<Publisher> GetPublisherByIdAsync(int publisherId)
        {
            return await Task.FromResult(
                SeedData.Publishers.FirstOrDefault(publisher => publisher.Id.Equals(publisherId)));
        }
    }
}
