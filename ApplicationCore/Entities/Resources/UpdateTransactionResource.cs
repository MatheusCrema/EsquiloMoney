using System;

namespace ApplicationCore.Entities.Resources
{
    public class UpdateTransactionResource
    {
        public int? TransactionID { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public string Comment { get; set; }


        public DateTime CreatedDT { get; set; }

    }

}
