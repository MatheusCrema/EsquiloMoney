using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ApplicationCore.Entities.Queries;
using ApplicationCore.Entities.Raw;
using ApplicationCore.Interfaces.Repositories.raw;

namespace Infrastructure.Data.Repositories.raw
{
    public class TransactionRawOldRepository : BaseRepository, ITransactionRawOldRepository
    {
        public TransactionRawOldRepository(AppDbContext context): base(context) { }

        public async Task<QueryResult<TransactionsRawOld>> ListAsync()
        {
            IQueryable<TransactionsRawOld> queryable = _context.TransactionsRawOlds;//.AsNoTracking();

            int totalItems = await queryable.CountAsync();

            List<TransactionsRawOld> transactionsRawOlds = await queryable.ToListAsync();

            return new QueryResult<TransactionsRawOld>
            {
                Items = transactionsRawOlds,
                TotalItems = totalItems
            };
        }

        public void Update(TransactionsRawOld transactionsRawOld)
        {
            _context.TransactionsRawOlds.Update(transactionsRawOld);
        }

    }
}
