using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Services.Communication;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<TransactionResponse> DeleteAsync(int id);

        Task<Transaction> FindByIdAsync(int id);

        Task<QueryResult<Transaction>> ListAsync(TransactionsQuery query);

        Task<TransactionResponse> SaveAsync(Transaction Transaction);

        Task<TransactionResponse> UpdateAsync(int id, Transaction Transaction);
    }
}
