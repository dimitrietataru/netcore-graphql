using GraphQL;
using GraphQL.Types;
using NetCore.GraphQLPrototype.App.Graph.Types;
using NetCore.GraphQLPrototype.Data.Services.Interfaces;

namespace NetCore.GraphQLPrototype.App.Graph.RootTypes
{
    public sealed class BookRootType : ObjectGraphType
    {
        private readonly IBookService bookService;

        public BookRootType(IBookService bookService)
        {
            this.bookService = bookService;

            RegisterGetBooks();
            RegisterGetBookByIsbn();
            RegisterGetBooksByAuthorId();
            RegisterGetBooksByPublisherId();
        }

        private void RegisterGetBooks()
        {
            FieldAsync<ListGraphType<BookType>>(
                name: "books",
                resolve: async context =>
                {
                    return await bookService.GetBooksAsync();
                });
        }

        private void RegisterGetBookByIsbn()
        {
            var args = new QueryArguments(new QueryArgument<IdGraphType> { Name = "isbn" });

            FieldAsync<PublisherType>(
                name: "bookByIsbn",
                arguments: args,
                resolve: async context =>
                {
                    string id = context.GetArgument<string>("isbn");

                    return await bookService.GetBookByIsbnAsync(id);
                });
        }

        private void RegisterGetBooksByAuthorId()
        {
            var args = new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" });

            FieldAsync<PublisherType>(
                name: "booksByAuthorId",
                arguments: args,
                resolve: async context =>
                {
                    int id = context.GetArgument<int>("id");

                    return await bookService.GetBooksByAuthorIdAsync(id);
                });
        }

        private void RegisterGetBooksByPublisherId()
        {
            var args = new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" });

            FieldAsync<PublisherType>(
                name: "booksByPublisherId",
                arguments: args,
                resolve: async context =>
                {
                    int id = context.GetArgument<int>("id");

                    return await bookService.GetBooksByPublisherIdAsync(id);
                });
        }
    }
}
