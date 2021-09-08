using System;

using System.ComponentModel.DataAnnotations;


namespace ApplicationCore.Entities.Resources
{
    public class SaveCategoryBalanceResource
    {
        [Required]
        [MaxLength(20)]
        public string Period { get; set; }
        
        [Required]
        public DateTime DateReference { get; set; }
        
        [Required]
        public decimal TotalExpense { get; set; }
        
        [Required]
        public decimal PlannedExpense { get; set; }
        
        [Required]
        public DateTime CreatedDT { get; set; }

        [Required]
        public int CategoryID { get; set; }
    }
}
