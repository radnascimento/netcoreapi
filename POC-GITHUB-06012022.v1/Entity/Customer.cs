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
        public string NameCustomer { get; set; }
        public string EmailCustomer { get; set; }
        public string Password { get; set; }

        public int IdStateCustomer { get; set; }

        public DateTime DateOperation { get; set; }

        public ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}
