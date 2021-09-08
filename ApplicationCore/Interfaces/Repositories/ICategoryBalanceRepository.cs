using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ICategoryBalanceRepository
    {
        Task AddAsync(CategoryBalance category);

        Task<QueryResult<CategoryBalance>> ListAsync(CategoryBalancesQuery query);
        Task<CategoryBalance> FindByIdAsync(int id);
        void Remove(CategoryBalance categorBalance);
    }
}
