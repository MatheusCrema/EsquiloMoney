using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<QueryResult<Transaction>> ListAsync(TransactionsQuery query);
        Task<Transaction> FindByIdAsync(int id);
        void Remove(Transaction transaction);
        void Update(Transaction transaction);
    }
}
