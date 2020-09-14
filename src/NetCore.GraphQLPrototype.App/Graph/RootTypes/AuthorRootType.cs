using GraphQL;
using GraphQL.Types;
using NetCore.GraphQLPrototype.App.Graph.Types;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;

namespace NetCore.GraphQLPrototype.App.Graph.RootTypes
{
    public sealed class AuthorRootType : ObjectGraphType
    {
        private readonly IAuthorService authorService;

        public AuthorRootType(IAuthorService authorService)
        {
            this.authorService = authorService;

            RegisterGetAuthors();
            RegisterGetAuthorById();
        }

        private void RegisterGetAuthors()
        {
            FieldAsync<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: async context =>
                {
                    return await authorService.GetAuthorsAsync();
                });
        }

        private void RegisterGetAuthorById()
        {
            var args = new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" });

            FieldAsync<AuthorType>(
                name: "authorById",
                arguments: args,
                resolve: async context =>
                {
                    int id = context.GetArgument<int>("id");

                    return await authorService.GetAuthorByIdAsync(id);
                });
        }
    }
}
