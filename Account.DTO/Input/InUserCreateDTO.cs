using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Account.DTO
{
    public class InUserCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public InPersonCreateDTO Person { get; set; }
    }
}
