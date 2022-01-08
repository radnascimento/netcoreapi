using POC_GITHUB_06012022.v1.Context;
using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly POCContext _pOCContext;

        public CustomerRepository(POCContext pOCContext)
        {
            _pOCContext = pOCContext;
        }

        public async Task<Customer> Retrieve(string name)
        {
            return _pOCContext.Customers.ToList().FirstOrDefault();

        }

        public async Task<Customer> Save(Customer customer)
        {
            customer.DateOperation = DateTime.Now;

            _pOCContext.Add(customer);
            await _pOCContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Retrieve(long id)
        {
            var customer = _pOCContext.Customers.Where(x => x.IdCustomer == id).FirstOrDefault();

            return customer;

        }

        public async Task Delete(Customer customer)
        {
            customer.DateOperation = DateTime.Now;
            _pOCContext.Update(customer);
            await _pOCContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAll()
        {
           return  _pOCContext.Customers.ToList();
        }
    }
}
