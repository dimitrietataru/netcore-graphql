using GraphQL.Types;
using NetCore.GraphQLPrototype.Data.Entities;

namespace NetCore.GraphQLPrototype.App.Graph.Types
{
    public sealed class PublisherType : ObjectGraphType<Publisher>
    {
        public PublisherType()
        {
            Field(publisher => publisher.Id);
            Field(publisher => publisher.Name);
        }
    }
}
