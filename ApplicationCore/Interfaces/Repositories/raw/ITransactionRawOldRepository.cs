using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationCore.Entities.Queries;
using ApplicationCore.Entities.Raw;

namespace ApplicationCore.Interfaces.Repositories.raw
{
    public interface ITransactionRawOldRepository
    {
        Task<QueryResult<TransactionsRawOld>> ListAsync();
        void Update(TransactionsRawOld transactionsRawOld);
    }
}
