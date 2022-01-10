using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Entity.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> Update(Customer customer);

        Task<Customer> Save(Customer customer);

        Task<Customer> Get(string name);
        Task<Customer> Get(long id);
        Task Delete(Customer customer);

        Task<List<Customer>> GetAll();
        Task<List<CustomerHistory>> GetHistory(long id);


    }

}
