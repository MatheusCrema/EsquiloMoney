using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;

using Infrastructure.Data.Common;

namespace Infrastructure.Data.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }
        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        public async Task<QueryResult<Category>> ListAsync(CategoriesQuery query)
        {
            IQueryable<Category> queryable = _context.Categories.AsNoTracking();


            //filtering
            if (query.Hierarchy.HasValue && query.Hierarchy >= 0)
            {
                
                queryable = queryable
                            .Include(p => p.CategoryBalances)
                            .Where(p => p.Hierarchy == query.Hierarchy);
            }

            //sorting
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                queryable = queryable.SortBy(query.SortBy);
                                           
            }

            int totalItems = await queryable.CountAsync();

            List<Category> categories = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                        .Take(query.ItemsPerPage)
                                                        .ToListAsync();

            return new QueryResult<Category>
            {
                Items = categories,
                TotalItems = totalItems
            };
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

    }
}
