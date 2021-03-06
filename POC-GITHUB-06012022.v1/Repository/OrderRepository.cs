using Microsoft.EntityFrameworkCore;
using POC_GITHUB_06012022.v1.Context;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Entity.History;
using POC_GITHUB_06012022.v1.Enum;
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

        public async Task<Order> Save(Order order)
        {
            //using var transaction = _pOCContext.Database.BeginTransaction();

            try
            {
                //save order
                var itens = order.Itens;

                order.Itens = null;

                order.DateOperation = DateTime.Now;

                _pOCContext.Orders.Add(order);

                await _pOCContext.SaveChangesAsync();

                //save itens
                foreach (var item in itens)
                {
                    item.IdOrder = order.IdOrder;
                    item.IdUser = order.IdUser;
                    item.DateOperation = order.DateOperation;
                    item.IdStateOrderItem = (int)EnumStateOrderItem.Saved;
                }

                await SaveItens(itens);

                //transaction.Commit();

                await SaveHistory(order.IdOrder);

                return order;

            }
            catch (Exception)
            {
                //whether any problem happens it will uncommit the transaction.
                //transaction.Rollback();
                throw;
            }
        }

        public async Task SaveItens(List<OrderItem> orderitens)
        {
            foreach (var item in orderitens)
            {
                _pOCContext.OrderItens.Add(item);
            }

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
            var order = _pOCContext.Orders.AsNoTracking().Where(x => x.IdOrder == id).FirstOrDefault();

            var orderitens = _pOCContext.OrderItens.AsNoTracking().Where(x => x.IdOrder == order.IdOrder).ToList();

            if (orderitens != null)
            {
                order.Itens = new List<OrderItem>();
                order.Itens = orderitens;
            }

            return order;
        }

        public async Task Update(Order order)
        {
            order.DateOperation = DateTime.Now;
            
            _pOCContext.Orders.Update(order);

            await _pOCContext.SaveChangesAsync();
            
            await SaveHistory(order.IdOrder);
        }

        public async Task Delete(Order order)
        {
            order.DateOperation = DateTime.Now;
            order.IdStateOrder = (int)EnumStateOrder.Deleted;

            _pOCContext.Orders.Update(order);

            await _pOCContext.SaveChangesAsync();

            await SaveHistory(order.IdOrder);

        }

        public async Task InTransit(Order order)
        {
            order.DateOperation = DateTime.Now;
            order.IdStateOrder = (int)EnumStateOrder.InTransit;

            _pOCContext.Orders.Update(order);
            
            await _pOCContext.SaveChangesAsync();

            await SaveHistory(order.IdOrder);

        }

        public async Task SaveHistory(long id)
        {
            var order = _pOCContext.Orders.AsNoTracking().Where(x => x.IdOrder == id).FirstOrDefault();

            if (order != null)
            {
                long IdOrderHistory = _pOCContext.OrderHistory.Count();

                _pOCContext.OrderHistory.Add(new OrderHistory
                {
                    IdOrderHistory = (IdOrderHistory == 0 ? 1 : IdOrderHistory + 1),
                    IdOrder = order.IdOrder,
                    IdCustomer = order.IdCustomer,
                    IdStateOrder = order.IdStateOrder,
                    IdTypePayment = order.IdTypePayment,
                    IdTypeDelivery = order.IdTypeDelivery,
                    IdAddressDelivery = order.IdAddressDelivery,
                    OrderDiscountPrice = order.OrderDiscountPrice,
                    OrderDeliveryPrice = order.OrderDeliveryPrice,
                    IdUser = order.IdUser,
                    DateOperation = order.DateOperation,
                    Itens = order.Itens
                });

                await _pOCContext.SaveChangesAsync();
            }
        }

        public async Task<List<OrderHistory>> GetHistory(long id)
        {
            return  _pOCContext.OrderHistory.Where(x => x.IdOrder == id).ToList();
        }
    }
}
