using System.Collections.Generic;

namespace ApplicationCore.Entities.Resources
{
    public class QueryResultResource<T>
    {
        public int TotalItems { get; set; } = 0;
        public List<T> Items { get; set; } = new List<T>();

    }
}
