using System;

namespace ApplicationCore.Entities
{
    public class PaymentType
    {
        public int? PaymentTypeID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDT { get; set; }
    } 
}
