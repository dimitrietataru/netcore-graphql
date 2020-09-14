using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using NetCore.GraphQLPrototype.App.Graph;
using NetCore.GraphQLPrototype.Data.Repositories;
using NetCore.GraphQLPrototype.Data.Repositories.Interfaces;
using NetCore.GraphQLPrototype.Data.Services;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;
using System;
using System.Linq;
using System.Reflection;

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
            services.AddGraphQLTypes();
            services.AddTransient<RootQuery>();

            services.AddGraphQl(schema =>
            {
                schema.SetQueryType<RootQuery>();
            });

            return services;
        }

        private static IServiceCollection AddGraphQLTypes(this IServiceCollection services)
        {
            ////services.AddTransient<AuthorType>();
            ////services.AddTransient<BookType>();
            ////services.AddTransient<PublisherType>();

            ////services.AddTransient<AuthorRootType>();
            ////services.AddTransient<BookRootType>();
            ////services.AddTransient<PublisherRootType>();

            var graphQLProject = Assembly.GetAssembly(typeof(RootQuery));
            var graphQLNamespace = graphQLProject.GetName().Name;
            var graphQLTypes = graphQLProject
                .GetTypes()
                .Where(type =>
                    type.IsClass
                    && type.IsPublic
                    && type.IsSubclassOf(typeof(GraphType))
                    && type.Namespace.StartsWith(graphQLNamespace))
                .Select(type => type.GetTypeInfo().AsType())
                .OfType<Type>()
                .ToList();

            foreach (var type in graphQLTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }
}
