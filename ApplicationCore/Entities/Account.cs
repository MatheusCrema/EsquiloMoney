using System;

namespace ApplicationCore.Entities
{
    public class Account
    {
        public int? AccountID { get; set; }

        public string Number { get; set; }

        public DateTime? ExpireDT { get; set; }

        public DateTime CreatedDT { get; set; }

        public int IdentityID { get; set; }

        public int InstitutionID { get; set; }

        public Identity Identity { get; set; } = new Identity();

        public Institution Institution { get; set; } = new Institution();

    }

}
