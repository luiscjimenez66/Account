using System;
using System.Collections.Generic;
using System.Text;

namespace Account.DTO.Output
{
    public class OutUserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public OutPersonDTO Person { get; set; }
    }
}
