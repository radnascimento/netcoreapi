using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.EntityDTO
{
    public class CustomerDto
    {
        [Required]
        public string NameCustomer { get; set; }
        [Required]
        public string EmailCustomer { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int IdStateCustomer { get; set; }


    }
}
