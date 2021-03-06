using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using POC_GITHUB_06012022.v1.Enum;
using System;
using POC_GITHUB_06012022.v1.Entity.History;

namespace POC_GITHUB_06012022.v1.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Save(Order order)
        {
            order.DateOperation = DateTime.Now;
            order.IdStateOrder = (int)EnumStateOrder.Saved;

            order = await _orderRepository.Save(order);

        }

        public async Task<ICollection<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> Get(long id)
        {
            return await _orderRepository.Get(id);
        }

        public async Task Update(Order order, int idstateorder)
        {
            order.IdStateOrder = idstateorder;
            await _orderRepository.Update(order);
        }

        public async Task Delete(Order id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task InTransit(Order order)
        {
            await _orderRepository.InTransit(order);
        }

        public async Task<List<OrderHistory>> GetHistory(long id)
        {
            return await _orderRepository.GetHistory(id);
        }
    }
}
