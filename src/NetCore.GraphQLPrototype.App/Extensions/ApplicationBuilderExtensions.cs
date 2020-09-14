using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NetCore.GraphQLPrototype.App.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQl(
                path: "/graphql",
                configure: options =>
                {
                    options.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                    options.ExposeExceptions = true;
                    options.FormatOutput = false;
                });

            if (env.IsDevelopment())
            {
                app.UseGraphiql(
                    path: "/graphiql",
                    configure: options =>
                    {
                        options.GraphQlEndpoint = "/graphql";
                    });
            }

            return app;
        }
    }
}
