using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Entity
{
    public class Customer
    {
        [Key]
        public long IdCustomer { get; set; }
        [Required]
        public string NameCustomer { get; set; }
        [Required]
        public string EmailCustomer { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int IdStateCustomer { get; set; }
        [Required]
        public DateTime DateOperation { get; set; }
        [Required]
        public long IdUser { get; set; }

        public ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}
