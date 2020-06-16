using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Account.DTO
{
    public class InPersonCreateDTO
    {
        [Required]
        public int IdentificationTypeId { get; set; }

        [Required]
        [MaxLength(15)]
        public string IdentificationNumber { get; set; }

        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }
    }
}
