using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int StatusId { get; set; }

        public int PersonId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public Person Person { get; set; }

        public Status Status { get; set; }

        public IList<UserBalance> UsersBalances { get; set; }
    }
}
