using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Services
{
    public interface ICustomerService
    {
        Task<Customer> Save(Customer customer);
        Task<Customer> Retrieve(string name);

        Task<Customer> Retrieve(long id);
        Task Delete(Customer customer);
        Task<List<Customer>> GetAll();
    }
}
