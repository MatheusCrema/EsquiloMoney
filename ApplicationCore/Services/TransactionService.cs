using System;
using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Interfaces.Services.Communication;

namespace ApplicationCore.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TransactionResponse> DeleteAsync(int id)
        {
            var existingTransaction = await _transactionRepository.FindByIdAsync(id);

            if (existingTransaction == null)
                return new TransactionResponse("Transaction not found");

            try
            {
                _transactionRepository.Remove(existingTransaction);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(existingTransaction);
            }
            catch (Exception ex)
            {
                return new TransactionResponse($"An error occurred when deleting the transaction: {ex.Message}");
            }

        }

        public async Task<Transaction> FindByIdAsync(int id)
        {
            return await _transactionRepository.FindByIdAsync(id);
        }

        public async Task<QueryResult<Transaction>> ListAsync(TransactionsQuery query)
        {
            return await _transactionRepository.ListAsync(query);
        }

        public async Task<TransactionResponse> SaveAsync(Transaction transaction)
        {
            try
            {
                await _transactionRepository.AddAsync(transaction);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(transaction);
            }
            catch (Exception ex)
            {
                return new TransactionResponse($"An error occurred when saving the Transaction: {ex.Message} n/ {ex.StackTrace}");
            }
        }

        public async Task<TransactionResponse> UpdateAsync(int id, Transaction transaction)
        {
            var existingTransaction = _transactionRepository.FindByIdAsync(id).Result;
            var resultingTransaction = new Transaction();

            try
            {
                if (existingTransaction == null)
                {
                    await _transactionRepository.AddAsync(transaction);
                    await _unitOfWork.CompleteAsync();

                    resultingTransaction = transaction;
                }
                else
                {
                    existingTransaction.Type = transaction.Type;
                    existingTransaction.Date = transaction.Date;
                    existingTransaction.Name = transaction.Name;
                    existingTransaction.Value = transaction.Value;
                    existingTransaction.Comment = transaction.Comment;
                    existingTransaction.OriginalCurrencyID = transaction.OriginalCurrencyID;
                    existingTransaction.OriginalValue = transaction.OriginalValue;
                    existingTransaction.CategoryID = transaction.CategoryID;
                    existingTransaction.PaymentTypeID = transaction.PaymentTypeID;
                    existingTransaction.AccountID = transaction.AccountID;
                    existingTransaction.CreatedDT = transaction.CreatedDT;


                    _transactionRepository.Update(existingTransaction);
                    await _unitOfWork.CompleteAsync();

                    resultingTransaction = existingTransaction;
                }

            }
            catch (Exception ex)
            {
                return new TransactionResponse($"An error occurred when saving the Transaction: {ex.Message} n/ {ex.StackTrace}");
            }

            return new TransactionResponse(resultingTransaction);

        }
    }
}
