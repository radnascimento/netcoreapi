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

            throw new NotImplementedException();
        }

        public async Task<ICollection<Order>> GetAll()
        {
            return _pOCContext.Orders.AsNoTracking().ToList();
        }

        public async Task<Order> Get(long id)
        {
            return _pOCContext.Orders.AsNoTracking().Where(x => x.IdOrder == id).FirstOrDefault();
        }
    }
}
