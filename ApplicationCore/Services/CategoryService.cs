using System;
using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services.Communication;
using ApplicationCore.Interfaces.Services;



namespace EsquiloMoney.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryBalanceRepository _categoryBalanceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryBalanceRepository categoryBalanceRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _categoryBalanceRepository = categoryBalanceRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
        public async Task<CategoryResponse> DeleteCascadeAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            try
            {

                var query = new CategoryBalancesQuery(id, 1, 100, "name");
                //var query = new CategoryBalancesQuery()
                //    Page = 1,
                //    ItemsPerPage = 100
                //};

                var existingCategoryBalances = await _categoryBalanceRepository.ListAsync(query);

                if (existingCategory != null && existingCategoryBalances.TotalItems > 0)
                {
                    foreach (CategoryBalance categoryBalance in existingCategoryBalances.Items)
                    {
                        _categoryBalanceRepository.Remove(categoryBalance);
                    }
                    await _unitOfWork.CompleteAsync();
                }

                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
        public async Task<Category> FindByIdAsync(int id)
        {
            return await _categoryRepository.FindByIdAsync(id);
        }
        public async Task<QueryResult<Category>> ListAsync(CategoriesQuery query)
        {
            return await _categoryRepository.ListAsync(query);
        }
        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when saving the Category: {ex.Message} n/ {ex.StackTrace}");
            }

        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {

            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            existingCategory.Name = category.Name ?? existingCategory.Name;
            existingCategory.Description = category.Description ?? existingCategory.Description;
            existingCategory.IconUI = category.IconUI ?? existingCategory.IconUI;
            existingCategory.Hierarchy = category.Hierarchy ?? existingCategory.Hierarchy;
            existingCategory.CreatedDT = existingCategory.CreatedDT;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when saving the Category: {ex.Message} n/ {ex.StackTrace}");
            }

        }
    }
}
