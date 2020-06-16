using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        public int IdentificationTypeId { get; set; }

        public string IdentificationNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int StatusId { get; set; }

        public User User { get; set; }

        public Status Status { get; set; }

        public IdentificationType IdentificationType { get; set; }
    }
}
