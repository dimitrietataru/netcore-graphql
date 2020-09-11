using Microsoft.Extensions.DependencyInjection;
using NetCore.GraphQLPrototype.App.Graph;
using NetCore.GraphQLPrototype.App.Graph.RootTypes;
using NetCore.GraphQLPrototype.App.Graph.Types;
using NetCore.GraphQLPrototype.Data.Repositories;
using NetCore.GraphQLPrototype.Data.Repositories.Interfaces;
using NetCore.GraphQLPrototype.Data.Services;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;

namespace NetCore.GraphQLPrototype.App.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IPublisherService, PublisherService>();

            return services;
        }

        public static IServiceCollection AddGraphQLDependencies(this IServiceCollection services)
        {
            services.AddTransient<AuthorType>();
            services.AddTransient<BookType>();
            services.AddTransient<PublisherType>();

            services.AddTransient<AuthorRootType>();
            services.AddTransient<BookRootType>();
            services.AddTransient<PublisherRootType>();

            services.AddTransient<RootQuery>();

            services.AddGraphQl(schema => schema.SetQueryType<RootQuery>());

            return services;
        }
    }
}
