
using ApplicationCore.Entities;



namespace ApplicationCore.Interfaces.Services.Communication
{
    public class IdentityResponse : BaseResponse
    {
        public Identity Identity { get; private set; }

        private IdentityResponse(bool success, string message, Identity identity) : base(success, message)
        {
            Identity = identity;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Identity">Saved Identity.</param>
        /// <returns>Response.</returns>
        public IdentityResponse(Identity Identity) : this(true, string.Empty, Identity)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public IdentityResponse(string message) : this(false, message, null)
        { }
    }
}
