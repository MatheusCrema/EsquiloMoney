


using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services.Communication
{
    public class CategoryBalanceResponse : BaseResponse
    {
        public CategoryBalance CategoryBalance { get; private set; }

        private CategoryBalanceResponse(bool success, string message, CategoryBalance categoryBalance) : base(success, message)
        {
            CategoryBalance = categoryBalance;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="CategoryBalance">Saved CategoryBalance.</param>
        /// <returns>Response.</returns>
        public CategoryBalanceResponse(CategoryBalance CategoryBalance) : this(true, string.Empty, CategoryBalance)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoryBalanceResponse(string message) : this(false, message, null)
        { }
    }
}
