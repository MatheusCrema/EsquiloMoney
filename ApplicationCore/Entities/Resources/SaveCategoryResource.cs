using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Resources
{
    public class SaveCategoryResource
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int Hierarchy { get; set; }

        public DateTime CreatedDT { get; set; }

        public int? CategoryParentID { get; set; }
    }

}
