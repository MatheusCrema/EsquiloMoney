using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<QueryResult<Category>> ListAsync(CategoriesQuery query);
        Task<Category> FindByIdAsync(int id);
        void Remove(Category category);

        void Update(Category category);
    }
}
