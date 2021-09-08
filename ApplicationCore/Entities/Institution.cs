using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Institution
    {
        public int? InstitutionID { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDT { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();

    }
}
