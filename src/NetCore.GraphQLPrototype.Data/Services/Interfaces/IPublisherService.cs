using NetCore.GraphQLPrototype.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetPublishersAsync();
        Task<Publisher> GetPublisherByIdAsync(int publisherId);
    }
}
