using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApplicationCore.Entities;



namespace ApplicationCore.Interfaces.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Category">Saved Category.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(Category Category) : this(true, string.Empty, Category)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(string message) : this(false, message, null)
        { }
    }
}
