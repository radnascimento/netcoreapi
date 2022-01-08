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

        public long IdCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string EmailCustomer { get; set; }
        public string Password { get; set; }
        public int IdStateCustomer { get; set; }
        public DateTime DateOperation { get; set; }
        public ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}
