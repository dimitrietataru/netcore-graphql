using GraphQL.Types;
using System.Collections.Generic;

namespace NetCore.GraphQLPrototype.App.Graph.Extensions
{
    public static class ObjectGraphTypeExtensions
    {
        public static void AddFields(this ObjectGraphType graph, IEnumerable<FieldType> fieldTypes)
        {
            foreach (var field in fieldTypes)
            {
                graph.AddField(field);
            }
        }
    }
}
