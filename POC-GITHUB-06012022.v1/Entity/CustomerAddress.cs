using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Entity
{
    public class CustomerAddress
    {
        [Key]
        public long IdCustomerAddress { get; set; }

        public long IdCustomer { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int ZipCode { get; set; }
        public int IdStateCustomerAddress { get; set; }
        public int Id { get; set; }
        public DateTime DateOperation { get; set; }

        public Customer Customer { get; set; }

    }
}
