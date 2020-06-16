using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }

        public string Code { get; set; }

        public string CurrencyName { get; set; }

        public string Symbol { get; set; }
    }
}
