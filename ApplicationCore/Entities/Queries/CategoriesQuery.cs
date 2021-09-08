namespace ApplicationCore.Entities.Queries
{
    public class CategoriesQuery : Query
    {
        public int? Hierarchy { get; set; }

        public CategoriesQuery(int? hierarchy, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            Hierarchy = hierarchy;
        }
    }
}
