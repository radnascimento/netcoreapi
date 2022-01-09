using Microsoft.EntityFrameworkCore;
using POC_GITHUB_06012022.v1.Context;
using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly POCContext _pOCContext;

        public OrderRepository(POCContext pOCContext)
        {
            _pOCContext = pOCContext;
        }

        public async Task Save(Order order)
        {
            order.DateOperation = DateTime.Now;

            _pOCContext.Orders.Add(order);

            await _pOCContext.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> GetAll()
        {
            var orders = _pOCContext.Orders.AsNoTracking().ToList();

            foreach (var item in orders)
            {
                var orderitens = _pOCContext.OrderItens.AsNoTracking().Where(x => x.IdOrder == item.IdOrder).ToList();

                if (orderitens != null)
                {
                    item.Itens = new List<OrderItem>();
                    item.Itens = orderitens;
                }
            }

            return orders;
        }

        public async Task<Order> Get(long id)
        {
            var order =  _pOCContext.Orders.AsNoTracking().Where(x => x.IdOrder == id).FirstOrDefault();

            var orderitens = _pOCContext.OrderItens.AsNoTracking().Where(x => x.IdOrder == order.IdOrder).ToList();

            if (orderitens != null)
            {
                order.Itens = new List<OrderItem>();
                order.Itens = orderitens;
            }

            return order;
        }
    }
}
