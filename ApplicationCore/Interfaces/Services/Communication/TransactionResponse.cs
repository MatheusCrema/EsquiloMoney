
using ApplicationCore.Entities;



namespace ApplicationCore.Interfaces.Services.Communication
{
    public class TransactionResponse : BaseResponse
    {
        public Transaction Transaction { get; private set; }

        private TransactionResponse(bool success, string message, Transaction transaction) : base(success, message)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Transaction">Saved Transaction.</param>
        /// <returns>Response.</returns>
        public TransactionResponse(Transaction transaction) : this(true, string.Empty, transaction)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TransactionResponse(string message) : this(false, message, null)
        { }
    }
}
