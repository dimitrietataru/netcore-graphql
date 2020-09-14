using System;

namespace NetCore.GraphQLPrototype.Data.Entities
{
    public sealed class Book
    {
        public string Isbn { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateTime PublishedAt { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
    }
}
