using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public async Task<Transaction> FindByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<QueryResult<Transaction>> ListAsync(TransactionsQuery query)
        {
            IQueryable<Transaction> queryable = _context.Transactions.AsNoTracking().Include(p => p.Account).Include(p => p.Category);//.Include(p => p.PaymentType);
            //.Include(p => p.Currency)

            int totalItems = await queryable.CountAsync();

            List<Transaction> transactions = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                        .Take(query.ItemsPerPage)
                                                        .ToListAsync();

            return new QueryResult<Transaction>
            {
                Items = transactions,
                TotalItems = totalItems
            };
        }

        public void Remove(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
        }

        public void Update(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
        }
    }
}