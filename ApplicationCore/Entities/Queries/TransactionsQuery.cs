namespace ApplicationCore.Entities.Queries
{
    public class TransactionsQuery : Query
    {

        public TransactionsQuery(int page, int itemsPerPage, string sortBy) : base(page, itemsPerPage, sortBy)
        {

        }
    }
}
