using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context): base(context) { }
           
       
        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }

        public async Task<Account> FindByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<QueryResult<Account>> ListAsync(AccountsQuery query)
        {
            IQueryable<Account> queryable = _context.Accounts.AsNoTracking().Include(p => p.Institution).Include(p => p.Identity);

            int totalItems = await queryable.CountAsync();

            List<Account> accounts = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                        .Take(query.ItemsPerPage)
                                                        .ToListAsync();

            return new QueryResult<Account>
            {
                Items = accounts,
                TotalItems = totalItems
            };
        }

        public void Remove(Account account)
        {
            _context.Accounts.Remove(account);
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }
    }
}
