using Microsoft.EntityFrameworkCore;
using POC_GITHUB_06012022.v1.Context;
using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Repository
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly POCContext _pOCContext;

        public CustomerAddressRepository(POCContext pOCContext)
        {
            _pOCContext = pOCContext;
        }
        public async Task<CustomerAddress> Get(string name)
        {
            List<CustomerAddress> data = new List<CustomerAddress>();

            return data.Where(x => x.StreetName == name).FirstOrDefault();
        }

        public async Task<CustomerAddress> Save(CustomerAddress customerAddress)
        {
            try
            {
                customerAddress.DateOperation = DateTime.Now;
                _pOCContext.CustomerAddress.Add(customerAddress);
                await _pOCContext.SaveChangesAsync();

                return customerAddress;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerAddress> Get(long id)
        {
            var customeradress = _pOCContext.CustomerAddress.AsNoTracking().Where(x => x.IdCustomer == id).ToList().FirstOrDefault();

            if (customeradress != null) customeradress.Customer = null;

            return customeradress;
        }
    }
}
