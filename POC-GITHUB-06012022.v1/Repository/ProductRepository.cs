using POC_GITHUB_06012022.v1.Context;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly POCContext _pOCContext;

        public ProductRepository(POCContext pOCContext)
        {
            _pOCContext = pOCContext;
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return _pOCContext.Products.ToList();
        }

        public async Task Save(Product product)
        {
            product.DateOperation = DateTime.Now;
            product.IdStateProduct = (int)EnumProduct.Register;

            _pOCContext.Products.Add(product);

            await _pOCContext.SaveChangesAsync();
        }

        public async Task<Product> Get(long id)
        {
            return _pOCContext.Products.Where(x => x.IdProduct == id).FirstOrDefault();
        }
    }
}
