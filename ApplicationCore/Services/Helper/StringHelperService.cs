using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationCore.Entities.Helper;

using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Repositories.raw;
using ApplicationCore.Interfaces.Services.Helper;


namespace ApplicationCore.Services.Helper
{
    public class StringHelperService : IStringHelperService
    {
        private readonly ITransactionRawOldRepository _transactionRawOldRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StringHelperService(ITransactionRawOldRepository transactionRawOldRepository, IUnitOfWork unitOfWork)
        {
            _transactionRawOldRepository = transactionRawOldRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task FormatDateFromColumn(string table, string column, string formatType)
        {
            var list_zero = _transactionRawOldRepository.ListAsync().Result.Items;

            var list = list_zero;

            foreach (var item in list)
            {
                var newDT = StringHelper.FormatDateBrazilToUS(item.Date);
                item.Date = newDT;

                _transactionRawOldRepository.Update(item);
            }
            await _unitOfWork.CompleteAsync();

        }
    }
}