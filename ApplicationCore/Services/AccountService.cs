using System;
using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Interfaces.Services.Communication;


namespace ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountResponse> DeleteAsync(int id)
        {
            var existingAccount = await _accountRepository.FindByIdAsync(id);

            if (existingAccount == null)
                return new AccountResponse("Account not found");

            try
            {
                _accountRepository.Remove(existingAccount);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(existingAccount);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error occurred when deleting the account: {ex.Message}");
            }
                        
        }

        public async Task<Account> FindByIdAsync(int id)
        {
            return await _accountRepository.FindByIdAsync(id);
        }

        public async Task<QueryResult<Account>> ListAsync(AccountsQuery query)
        {
            return await _accountRepository.ListAsync(query);
        }

        public async Task<AccountResponse> SaveAsync(Account account)
        {
            try
            {
                await _accountRepository.AddAsync(account);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(account);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error occurred when saving the Account: {ex.Message} n/ {ex.StackTrace}");
            }
        }

        public async Task<AccountResponse> UpdateAsync(Account account)
        {
            var existingAccount = _accountRepository.FindByIdAsync(account.AccountID.Value).Result;
            var resultingAccount = new Account();

            try
            {
                if (existingAccount == null)
                {
                    await _accountRepository.AddAsync(account);
                    await _unitOfWork.CompleteAsync();

                    resultingAccount = account;
                } 
                else
                {
                    existingAccount.AccountID = account.AccountID;
                    existingAccount.CreatedDT = account.CreatedDT;
                    existingAccount.ExpireDT = account.ExpireDT;
                    existingAccount.IdentityID = account.IdentityID;
                    existingAccount.InstitutionID = account.InstitutionID;
                    existingAccount.Number = account.Number;

                    _accountRepository.Update(existingAccount);
                    await _unitOfWork.CompleteAsync();

                    resultingAccount = existingAccount;
                }

            } 
            catch (Exception ex)
            {
                return new AccountResponse($"An error occurred when saving the Account: {ex.Message} n/ {ex.StackTrace}");
            }

            return new AccountResponse(resultingAccount);

        }
    }
}
