using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Account.DTO.Input
{
    public class InTransactionDTO
    {
        [Required]
        public int TransactionTypeId { get; set; }

        public string UserName { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
