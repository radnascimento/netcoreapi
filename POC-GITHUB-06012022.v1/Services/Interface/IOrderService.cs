using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Entity.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Services
{
    public interface IOrderService
    {

        Task Delete(Order id);
        Task<ICollection<Order>> GetAll();
        Task<List<OrderHistory>> GetHistory(long id);
        Task<Order> Get(long id);
        Task Save(Order order);
        Task Update(Order order, int idstateorder);
        Task InTransit(Order order);

    }
}
