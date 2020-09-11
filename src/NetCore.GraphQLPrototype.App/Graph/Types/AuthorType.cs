using GraphQL.Types;
using NetCore.GraphQLPrototype.Data.Entities;

namespace NetCore.GraphQLPrototype.App.Graph.Types
{
    public sealed class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(author => author.Id);
            Field(author => author.Name);
        }
    }
}
