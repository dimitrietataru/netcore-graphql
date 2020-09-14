using GraphQL.Types;
using NetCore.GraphQLPrototype.Data.Entities;

namespace NetCore.GraphQLPrototype.App.Graph.Types
{
    public sealed class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(book => book.Isbn);
            Field(book => book.Title);
            Field(book => book.SubTitle);
            Field(book => book.Description);
            Field(book => book.Pages);
            Field(book => book.PublishedAt);
            Field<AuthorType>(nameof(Book.Author));
            Field<PublisherType>(nameof(Book.Publisher));
        }
    }
}
