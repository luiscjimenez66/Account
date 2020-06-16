using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public int TransactionTypeId { get; set; }

        public int BalanceId { get; set; }

        public int? DestinationBalanceId { get; set; }

        public int? UserId { get; set; }

        public decimal CurrentAmount { get; set; }

        public DateTime CreateAt { get; set; }

        public Balance Balance { get; set; }

        public Balance DestinationBalance { get; set; }

        public User User { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
