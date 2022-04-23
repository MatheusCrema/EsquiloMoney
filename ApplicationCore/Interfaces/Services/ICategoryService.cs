using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Services.Communication;

namespace ApplicationCore.Interfaces.Services
{
    public interface ICategoryService
    {

        Task<CategoryResponse> DeleteAsync(int id);

        Task<CategoryResponse> DeleteCascadeAsync(int id);

        Task<Category> FindByIdAsync(int id);

        Task<QueryResult<Category>> ListAsync(CategoriesQuery query);

        Task<CategoryResponse> SaveAsync(Category category);

        Task<CategoryResponse> UpdateAsync(int id, Category category);

    }
}
