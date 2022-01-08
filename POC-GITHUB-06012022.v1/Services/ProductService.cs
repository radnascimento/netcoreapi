using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using POC_GITHUB_06012022.v1.Enum;

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

        public async Task Save(Product product)
        {
            product.IdStateProduct = (int)EnumProduct.Register;
            await _productRepository.Save(product);
        }

        public async Task<Product> Get(long id)
        {
            return await _productRepository.Get(id);
        }
    }
}
