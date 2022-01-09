using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Entity.History
{
    public class CustomerHistory
    {
        [Key]
        public long IdCustomerHistory { get; set; }
        [Required]
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
