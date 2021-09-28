using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Resources
{
    public class IdentityResource
    {
        public int? IdentityID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedDT { get; set; }

        public List<AccountResource> Accounts { get; set; } = new List<AccountResource>();

    }
}
