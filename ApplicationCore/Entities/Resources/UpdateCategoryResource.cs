using System;

using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Resources
{
    public class UpdateCategoryResource
    {
        public int CategoryID { get; set; }

        
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int? Hierarchy { get; set; }

        public DateTime CreatedDT { get; set; }

        public int? CategoryParentID { get; set; }
    }

}
