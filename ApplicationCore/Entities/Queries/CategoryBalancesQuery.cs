namespace ApplicationCore.Entities.Queries
{
    public class CategoryBalancesQuery : Query
    {
        public int? CategoryID { get; set; }
        public CategoryBalancesQuery(int? categoryID, int page, int itemsPerPage, string sortBy) : base(page, itemsPerPage, sortBy)
        {
            CategoryID = categoryID;
        }

    }
}
