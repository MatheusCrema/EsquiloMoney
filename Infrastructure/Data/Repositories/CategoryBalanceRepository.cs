using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Data.Repositories
{
    public class CategoryBalanceRepository : BaseRepository, ICategoryBalanceRepository
    {
        public CategoryBalanceRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(CategoryBalance categoryBalance)
        {
            await _context.CategoryBalances.AddAsync(categoryBalance);
        }
        public async Task<CategoryBalance> FindByIdAsync(int id)
        {
            return await _context.CategoryBalances.FindAsync(id);
        }
        public async Task<QueryResult<CategoryBalance>> ListAsync(CategoryBalancesQuery query)
        {
            IQueryable<CategoryBalance> queryable = _context.CategoryBalances.AsNoTracking();

            if (query.CategoryID.HasValue && query.CategoryID >= 0)
            {
                queryable = queryable
                            .Where(p => p.CategoryID == query.CategoryID);
            }

            int totalItems = await queryable.CountAsync();
            List<CategoryBalance> categoryBalances = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                                    .Take(query.ItemsPerPage)
                                                                    .ToListAsync();

            return new QueryResult<CategoryBalance>
            {
                Items = categoryBalances,
                TotalItems = totalItems
            };
        }
        public void Remove(CategoryBalance categoryBalance)
        {
            _context.CategoryBalances.Remove(categoryBalance);
        }
    }
}
