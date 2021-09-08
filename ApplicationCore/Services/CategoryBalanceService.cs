using System;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services.Communication;
using Domain.Services;

using System.Threading.Tasks;


namespace EsquiloMoney.API.Services
{
    public class CategoryBalanceService : ICategoryBalanceService
    {
        private readonly ICategoryBalanceRepository _categoryBalanceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryBalanceService(ICategoryBalanceRepository categoryBalanceRepository, IUnitOfWork unitOfWork)
        {
            _categoryBalanceRepository = categoryBalanceRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<CategoryBalanceResponse> DeleteAsync(int id)
        {
            var existingCategoryBalance = await _categoryBalanceRepository.FindByIdAsync(id);

            if (existingCategoryBalance == null)
                return new CategoryBalanceResponse("Category Balance not found.");

            try
            {
                _categoryBalanceRepository.Remove(existingCategoryBalance);
                await _unitOfWork.CompleteAsync();

                return new CategoryBalanceResponse(existingCategoryBalance);
            }
            catch (Exception ex)
            {
                return new CategoryBalanceResponse($"An error occurred when deleting the category balance: {ex.Message}.");
            }
        }

        public async Task<QueryResult<CategoryBalance>> ListAsync(CategoryBalancesQuery query)
        {
            return await _categoryBalanceRepository.ListAsync(query);
        }

        public async Task<CategoryBalanceResponse> SaveAsync(CategoryBalance categoryBalance)
        {
            try
            {
                await _categoryBalanceRepository.AddAsync(categoryBalance);
                await _unitOfWork.CompleteAsync();

                return new CategoryBalanceResponse(categoryBalance);
            }
            catch(Exception ex)
            {
                return new CategoryBalanceResponse($"An error occurred when saving the category balance: {ex.Message} n/ {ex.StackTrace}");
            }
        }
    }
}
