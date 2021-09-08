using System;

namespace ApplicationCore.Entities
{
    public class Currency
    {
        public int? CurrencyID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Country { get; set; }

        public DateTime CreatedDT { get; set; }
    }


}
