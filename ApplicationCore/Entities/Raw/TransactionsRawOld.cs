using System;

namespace ApplicationCore.Entities.Raw
{
    public class TransactionsRawOld
    {
        public int ID { get; set; }
        public int? matchedCategoryID { get; set; }
        public string Date { get; set; }
        public string Cod { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Payment { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
    }

}
