using GraphQL.Types;
using NetCore.GraphQLPrototype.App.Graph.Extensions;
using NetCore.GraphQLPrototype.App.Graph.RootTypes;

namespace NetCore.GraphQLPrototype.App.Graph
{
    public sealed class RootQuery : ObjectGraphType
    {
        public RootQuery(
            AuthorRootType authorRootType,
            BookRootType bookRootType,
            PublisherRootType publisherRootType)
        {
            this.AddFields(authorRootType.Fields);
            this.AddFields(bookRootType.Fields);
            this.AddFields(publisherRootType.Fields);
        }
    }
}
