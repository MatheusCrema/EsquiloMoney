using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Identity
    {
        public int? IdentityID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDT { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();

    }





}
