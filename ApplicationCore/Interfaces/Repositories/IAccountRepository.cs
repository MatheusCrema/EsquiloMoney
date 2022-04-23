using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task<QueryResult<Account>> ListAsync(AccountsQuery query);
        Task<Account> FindByIdAsync(int id);
        void Remove(Account account);
        void Update(Account account);
    }
}
