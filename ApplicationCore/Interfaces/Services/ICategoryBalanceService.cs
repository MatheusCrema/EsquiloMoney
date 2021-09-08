using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Services.Communication;

namespace Domain.Services
{
    public interface ICategoryBalanceService
    {
        Task<QueryResult<CategoryBalance>> ListAsync(CategoryBalancesQuery query);

        Task<CategoryBalanceResponse> SaveAsync(CategoryBalance categoryBalance);

        Task<CategoryBalanceResponse> DeleteAsync(int id);
    }
}
