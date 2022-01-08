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

        public async Task<Product> Save(Product product)
        {
            product.DateOperation = DateTime.Now;

            _pOCContext.Products.Add(product);

            await _pOCContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Get(long id)
        {
            return _pOCContext.Products.Where(x => x.IdProduct == id).FirstOrDefault();
        }

        public async Task<Product> Update(Product product)
        {
            product.DateOperation = DateTime.Now;

            _pOCContext.Products.Update(product);

            await _pOCContext.SaveChangesAsync();

            await SaveHistory(product.IdProduct);

            return product;
        }

        public async Task Delete(Product product)
        {
            product.DateOperation = DateTime.Now;

            _pOCContext.Products.Update(product);

            await _pOCContext.SaveChangesAsync();

            await SaveHistory(product.IdProduct);
            
        }

        //lixo
        public async Task SaveHistory(long id)
        {
            //todo
        }
    }
}
