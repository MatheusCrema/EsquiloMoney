using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Resources
{
    public class CategoryResource
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hierarchy { get; set; }
        public string IconUI { get; set; }
        public DateTime CreatedDT { get; set; }
        public int? CategoryParentID { get; set; }
        public List<CategoryBalance> CategoryBalances { get; set; } = new List<CategoryBalance>();
    }
}
