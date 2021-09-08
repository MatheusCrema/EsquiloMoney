using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Services.Communication;

namespace Domain.Services
{
    public interface IAccountService
    {

        Task<AccountResponse> DeleteAsync(int id);

        Task<Account> FindByIdAsync(int id);

        Task<QueryResult<Account>> ListAsync(AccountsQuery query);

        Task<AccountResponse> SaveAsync(Account account);

        Task<AccountResponse> UpdateAsync(Account account);

    }
}
