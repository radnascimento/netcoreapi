using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Repository
{
    public interface IOrderRepository
    {
        Task SaveItens(List<OrderItem> orderitens);
        Task<ICollection<Order>> GetAll();
        Task<Order> Get(long id);

        Task Delete(Order id);
        Task<Order> Save(Order order);

        Task Update(Order order);
    }
}
