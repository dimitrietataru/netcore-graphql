using System.Collections.Generic;

namespace NetCore.GraphQLPrototype.Data.Entities
{
    public sealed class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> Publishers { get; set; } = new List<int>();
    }
}
