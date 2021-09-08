using System;

namespace ApplicationCore.Entities
{
    public class CategoryBalance
    {
        public int CategoryBalanceID { get; set; }
        public string Period { get; set; }
        public DateTime DateReference { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal PlannedExpense { get; set; }
        public DateTime CreatedDT { get; set; }

        public int CategoryID { get; set; }
        //public Category Category { get; set; } - being commented out as it isn't required now
    }

}
