namespace ApplicationCore.Entities.Queries
{
    public class AccountsQuery : Query
    {

        public AccountsQuery(int page, int itemsPerPage, string sortBy) : base(page, itemsPerPage, sortBy)
        {
            
        }
    }
}
