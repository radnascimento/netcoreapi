using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Enum;
using POC_GITHUB_06012022.v1.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace POC_GITHUB_06012022.v1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerReposity;
        private readonly ICustomerAddressRepository _customerAddressReposity;

        public CustomerService(ICustomerRepository customerReposity,
            ICustomerAddressRepository customerAddressReposity
            )
        {
            _customerReposity = customerReposity;
            _customerAddressReposity = customerAddressReposity;
        }

        public async Task<Customer> Get(string name)
        {
            return await _customerReposity.Get(name);
        }

        public async Task<Customer> Save(Customer customer)
        {
            customer.IdStateCustomer = (int)EnumStateCustomer.Saved;
            customer.IdUser = 1;
            return await _customerReposity.Save(customer);
        }

        public async Task<Customer> Update(Customer customer)
        {

            if (await Get(customer.IdCustomer) != null)
            {
                customer.IdStateCustomer = (int)EnumStateCustomer.Updated;
                customer = await _customerReposity.Update(customer);
            }
            else { throw new ArgumentException("Not found"); }

            return customer;
        }

        public async Task<Customer> Get(long id)
        {
            var customer = await _customerReposity.Get(id);

            if (customer != null)
            {
                return await LoadCustomerAddress(customer);
            }

            return customer;
        }

        public async Task Delete(Customer customer)
        {
            
            if (await Get(customer.IdCustomer) != null)
            {
                customer.IdStateCustomer = (int)EnumStateCustomer.Deleted;
                await _customerReposity.Delete(customer);
            }
            else { throw new ArgumentException("Not found"); }

        }

        public async Task<List<Customer>> GetAll()
        {
            var customers = await _customerReposity.GetAll();

            foreach (var item in customers)
            {
                await LoadCustomerAddress(item);
            }

            return customers;
        }

        public async Task<Customer> LoadCustomerAddress(Customer customer)
        {
            if (customer != null)
            {
                if (customer.CustomerAddress == null)
                {
                    var customerAddress = await _customerAddressReposity.Get(customer.IdCustomer);

                    if (customerAddress != null)
                    {
                        List<CustomerAddress> Addresses = new List<CustomerAddress>();

                        Addresses.Add(customerAddress);
                        customer.CustomerAddress = Addresses;
                    }
                }
            }
            return customer;
        }
    }
}
