using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Enum;
using POC_GITHUB_06012022.v1.Repository;
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

        public async Task<Customer> Retrieve(string name)
        {
            return await _customerReposity.Retrieve(name);
        }

        public async Task<Customer> Save(Customer customer)
        {
            customer.IdStateCustomer = (int)EnumStateCustomer.Register;

            return await _customerReposity.Save(customer);
        }

        public async Task<Customer> Retrieve(long id)
        {
            return await LoadCustomerAddress(await _customerReposity.Retrieve(id));
        }

        public async Task Delete(Customer customer)
        {
            customer.IdStateCustomer = (int)EnumStateCustomer.Deleted;
            await _customerReposity.Delete(customer);
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
            if (customer.CustomerAddress == null)
            {
                var customerAddress = await _customerAddressReposity.Retrieve(customer.IdCustomer);
                List<CustomerAddress> customerAddresses = new List<CustomerAddress>();
                customerAddresses.Add(customerAddress);
                customer.CustomerAddress = customerAddresses;
            }
            return customer;
        }
    }
}
