using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Services
{
    public interface ICustomerAddressService
    {
        Task<CustomerAddress> Save(CustomerAddress customer);
        Task<CustomerAddress> Get(string name);

        Task<CustomerAddress> Get(long id);
    }
}
