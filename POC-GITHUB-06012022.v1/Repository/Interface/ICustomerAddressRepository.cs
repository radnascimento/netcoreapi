using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Repository
{
    public interface ICustomerAddressRepository
    {
        Task<CustomerAddress> Save(CustomerAddress customerAddress);

        Task<CustomerAddress> Retrieve(string name);

        Task<CustomerAddress> Retrieve(long id);


    }
}
