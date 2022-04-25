using System;

namespace ApplicationCore.Entities.Resources
{
    public class AccountResource
    {
        public int? AccountID { get; set; }

        public string Number { get; set; }

        public DateTime ExpireDT { get; set; }

        public DateTime CreatedDT { get; set; }

    }

}
