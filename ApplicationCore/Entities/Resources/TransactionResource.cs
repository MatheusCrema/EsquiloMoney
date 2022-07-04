using System;

namespace ApplicationCore.Entities.Resources
{
    public class TransactionResource
    {
        public int? TransactionID { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public string Comment { get; set; }

        //public int OriginalCurrencyID { get; set; }

        //public decimal OriginalValue { get; set; }

        //public int CategoryID { get; set; }

        //public int PaymentTypeID { get; set; }

        //public int AccountID { get; set; }

        public DateTime CreatedDT { get; set; }

        //public AccountResource Account { get; set; } = new AccountResource();

        //public CategoryResource Category { get; set; } = new CategoryResource();

        ////public Currency Currency { get; set; } = new Currency();

        //public PaymentType PaymentType { get; set; } = new PaymentType();
    }


}
