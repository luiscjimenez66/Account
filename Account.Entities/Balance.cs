using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Entities
{
    public class Balance
    {
        public int BalanceId { get; set; }

        public int CurrencyId { get; set; }

        public int StatusId { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public Currency Currency { get; set; }

        public Status Status { get; set; }

        public IList<UserBalance> UsersBalances { get; set; }

        public IList<Transaction> Transactions { get; set; }
    }
}
