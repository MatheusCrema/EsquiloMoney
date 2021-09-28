using System;
using System.Collections.Generic;


namespace ApplicationCore.Entities.Resources
{
    public class UpdateIdentityResource
    {
        public int? IdentityID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedDT { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();
    }



}
