using System;
using System.Collections.Generic;
using System.Text;

namespace Account.BusinessLayer
{
    public class Configuration
    {
        public enum eStatuses
        {
            ACTIVE = 1,
            INACTIVE = 2
        }

        public enum eCurrencies
        {
            EURO = 1
        }

        public enum eTransactionType
        {
            DEPOSIT = 1,
            WITHDRAW = 2,
            TRANSFER_MONEY = 3

        }
    }
}
