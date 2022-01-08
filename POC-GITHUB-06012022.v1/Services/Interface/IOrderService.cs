using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Services
{
    public interface IOrderService
    {

        Task<ICollection<Order>> GetAll();

        Task<Order> Get(long id);

        Task Save(Order order);
    }
}
