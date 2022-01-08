using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Repository;
using System.Threading.Tasks;
using POC_GITHUB_06012022.v1.Enum;


namespace POC_GITHUB_06012022.v1.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly ICustomerAddressRepository _customerAddressReposity;

        public CustomerAddressService(ICustomerAddressRepository customerAddressReposity)
        {
            _customerAddressReposity = customerAddressReposity;
        }

        public async Task<CustomerAddress> Retrieve(string name)
        {
            return await _customerAddressReposity.Retrieve(name);
        }

        public  async Task<CustomerAddress> Save(CustomerAddress customer)
        {
            customer.IdStateCustomerAddress = (int)EnumCustomerAddress.Register;
            return await _customerAddressReposity.Save(customer);
        }

        public async Task<CustomerAddress> Retrieve(long id)
        {
            return await _customerAddressReposity.Retrieve(id);

        }

    }
}
