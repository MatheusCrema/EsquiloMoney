using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class IdentityRepository : BaseRepository, IIdentityRepository
    {
        public IdentityRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Identity identity)
        {
            await _context.Identities.AddAsync(identity);
        }

        public async Task<Identity> FindByIdAsync(int id)
        {
            return await _context.Identities.FindAsync(id);
        }

        public async Task<QueryResult<Identity>> ListAsync(IdentitiesQuery query)
        {
            IQueryable<Identity> queryable = _context.Identities.AsNoTracking().Include(p => p.Accounts);

            int totalItems = await queryable.CountAsync();

            List<Identity> identities = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                        .Take(query.ItemsPerPage)
                                                        .ToListAsync();

            return new QueryResult<Identity>
            {
                Items = identities,
                TotalItems = totalItems
            };
        }

        public void Remove(Identity identity)
        {
            _context.Identities.Remove(identity);
        }

        public void Update(Identity identity)
        {
            throw new System.NotImplementedException();
        }
    }
}
