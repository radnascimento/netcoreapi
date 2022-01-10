using POC_GITHUB_06012022.v1.Context;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Entity.History;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Customer> Get(string name)
        {
            return _pOCContext.Customers.AsNoTracking().ToList().FirstOrDefault();

        }

        public async Task<Customer> Save(Customer customer)
        {
            customer.DateOperation = DateTime.Now;

            _pOCContext.Customers.Add(customer);

            await _pOCContext.SaveChangesAsync();

            await SaveHistory(customer.IdCustomer);

            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            customer.DateOperation = DateTime.Now;

            _pOCContext.Customers.Update(customer);

            await _pOCContext.SaveChangesAsync();
            
            await SaveHistory(customer.IdCustomer);

            return customer;
        }


        public async Task<Customer> Get(long id)
        {

            var customer = _pOCContext.Customers.Where(x => x.IdCustomer == id).AsNoTracking().FirstOrDefault();

            return customer;

        }

        public async Task Delete(Customer customer)
        {
            customer.DateOperation = DateTime.Now;
            _pOCContext.Customers.Update(customer);
            await _pOCContext.SaveChangesAsync();

            await SaveHistory(customer.IdCustomer);
        }

        public async Task<List<Customer>> GetAll()
        {
            return _pOCContext.Customers.AsNoTracking().ToList();
        }


        public async Task SaveHistory(long id)
        {
            var customer = _pOCContext.Customers.AsNoTracking().Where(x => x.IdCustomer == id).FirstOrDefault();

            if (customer != null)
            {
                long IdCustomerHistory = _pOCContext.CustomerHistory.Count();

                _pOCContext.CustomerHistory.Add(new CustomerHistory
                {
                    IdCustomerHistory = (IdCustomerHistory == 0 ? 1 : IdCustomerHistory + 1),
                    IdCustomer = customer.IdCustomer,
                    CustomerAddress = customer.CustomerAddress,
                    DateOperation = customer.DateOperation,
                    EmailCustomer = customer.EmailCustomer,
                    IdStateCustomer = customer.IdStateCustomer,
                    NameCustomer = customer.NameCustomer,
                    Password = customer.Password
                });

                await _pOCContext.SaveChangesAsync();
            }
        }

        public async Task<List<CustomerHistory>> GetHistory(long id)
        {
           return _pOCContext.CustomerHistory.AsNoTracking().Where(x => x.IdCustomer == id).ToList();
        }
    }
}
