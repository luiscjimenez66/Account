using System;
using System.Collections.Generic;
using System.Text;

namespace Account.DTO.Output
{
    public class OutAuthenticateDTO
    {
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
