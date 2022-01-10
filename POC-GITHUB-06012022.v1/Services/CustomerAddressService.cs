using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Repository;
using System.Threading.Tasks;
using POC_GITHUB_06012022.v1.Enum;


namespace POC_GITHUB_06012022.v1.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public CustomerAddressService(ICustomerAddressRepository customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;
        }

        public async Task<CustomerAddress> Get(string name)
        {
            return await _customerAddressRepository.Get(name);
        }

        public  async Task<CustomerAddress> Save(CustomerAddress customer)
        {
            customer.IdStateCustomerAddress = (int)EnumCustomerAddress.Saved;
            return await _customerAddressRepository.Save(customer);
        }

        public async Task<CustomerAddress> Get(long id)
        {
            return await _customerAddressRepository.Get(id);

        }

    }
}
