using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Entity.History;
using POC_GITHUB_06012022.v1.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Services
{
    public interface ICustomerService
    {
        Task<Customer> Update(Customer customer, int idstatecustomer);
        Task Delete(Customer customer);

        Task<Customer> Save(Customer customer);
        Task<Customer> Get(string name);

        Task<Customer> Get(long id);
        Task<List<Customer>> GetAll();

        Task<List<CustomerHistory>> GetHistory(long id);


    }
}
