using GraphQL;
using GraphQL.Types;
using NetCore.GraphQLPrototype.App.Graph.Types;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;

namespace NetCore.GraphQLPrototype.App.Graph.RootTypes
{
    public sealed class PublisherRootType : ObjectGraphType
    {
        private readonly IPublisherService publisherService;

        public PublisherRootType(IPublisherService publisherService)
        {
            this.publisherService = publisherService;

            RegisterGetPublishers();
            RegisterGetPublisherById();
        }

        private void RegisterGetPublishers()
        {
            FieldAsync<ListGraphType<PublisherType>>(
                name: "publishers",
                resolve: async context =>
                {
                    return await publisherService.GetPublishersAsync();
                });
        }

        private void RegisterGetPublisherById()
        {
            var args = new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" });

            FieldAsync<PublisherType>(
                name: "publisherById",
                arguments: args,
                resolve: async context =>
                {
                    int id = context.GetArgument<int>("id");

                    return await publisherService.GetPublisherByIdAsync(id);
                });
        }
    }
}
