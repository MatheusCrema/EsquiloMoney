
using ApplicationCore.Entities;



namespace ApplicationCore.Interfaces.Services.Communication
{
    public class AccountResponse : BaseResponse
    {
        public Account Account { get; private set; }

        private AccountResponse(bool success, string message, Account account) : base(success, message)
        {
            Account = account;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Account">Saved Account.</param>
        /// <returns>Response.</returns>
        public AccountResponse(Account account) : this(true, string.Empty, account)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AccountResponse(string message) : this(false, message, null)
        { }
    }
}
