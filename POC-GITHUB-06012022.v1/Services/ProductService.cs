using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using POC_GITHUB_06012022.v1.Enum;
using System;

namespace POC_GITHUB_06012022.v1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<ICollection<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> Save(Product product)
        {
            product.IdStateProduct = (int)EnumStateProduct.Saved;
            return await _productRepository.Save(product);
        }

        public async Task<Product> Get(long id)
        {
            var product = await _productRepository.Get(id);

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            if (await Get(product.IdProduct) != null)
            {
                product.IdStateProduct = (int)EnumStateProduct.Updated;
                product = await _productRepository.Update(product);
            }
            else { throw new ArgumentException("Not found"); }


            return product;
        }

        public async Task Delete(Product product)
        {

            if (await Get(product.IdProduct) != null)
            {
                product.IdStateProduct = (int)EnumStateProduct.Deleted;
                await _productRepository.Delete(product);
            }
            else { throw new ArgumentException("Not found"); }
        }
    }
}
