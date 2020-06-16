using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Entities
{
    public class UserBalance
    {
        public int UserId { get; set; }

        public int BalanceId { get; set; }

        public bool Principal { get; set; }

        public bool PermissionAdmin { get; set; }

        public User User { get; set; }

        public Balance Balance { get; set; }
    }
}
