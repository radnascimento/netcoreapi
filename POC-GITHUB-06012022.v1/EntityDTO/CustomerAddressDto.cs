using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.EntityDTO
{
    public class CustomerAddressDto
    {
        [Required]
        public long IdCustomer { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
