
namespace ApplicationCore.Entities.Queries
{
    public class Query
    {
        public int Page { get; protected set; }
        public int ItemsPerPage { get; protected set; }
        public string SortBy { get; protected set; }

        public Query(int page, int itemsPerPage, string sortBy)
        {
            Page = page;
            ItemsPerPage = itemsPerPage;
            SortBy = sortBy;

            if (Page <= 0)
            {
                Page = 1;
            }

            if (ItemsPerPage <= 0)
            {
                ItemsPerPage = 10;
            }
        }
    }
}
