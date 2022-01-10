using Microsoft.EntityFrameworkCore;
using POC_GITHUB_06012022.v1.Context;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Entity.History;
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
            return _pOCContext.Products.AsNoTracking().ToList();
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
            return _pOCContext.Products.AsNoTracking().Where(x => x.IdProduct == id).FirstOrDefault();
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

        
        public async Task SaveHistory(long id)
        {
            var product = _pOCContext.Products.AsNoTracking().Where(x => x.IdProduct == id).FirstOrDefault();

            if (product != null)
            {
                long IdProductHistory = _pOCContext.ProductHistory.Count();

                _pOCContext.ProductHistory.Add(new ProductHistory
                {
                    IdProductHistory = (IdProductHistory == 0 ? 1 : IdProductHistory + 1),
                    IdProduct = product.IdProduct,
                    NameProduct = product.NameProduct,
                    IdStateProduct = product.IdStateProduct,
                    DateOperation = product.DateOperation
                });

                await _pOCContext.SaveChangesAsync();
            }
        }

        public async Task<List<ProductHistory>> GetHistory(long id)
        {
            return _pOCContext.ProductHistory.Where(x => x.IdProduct == id).ToList();
        }
    }
}
