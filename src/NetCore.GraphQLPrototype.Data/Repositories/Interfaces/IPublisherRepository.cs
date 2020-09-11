using NetCore.GraphQLPrototype.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.GraphQLPrototype.Data.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetPublishersAsync();
        Task<Publisher> GetPublisherByIdAsync(int publisherId);
    }
}
