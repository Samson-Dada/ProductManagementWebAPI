
using ProductManagementPlaftormAPI.DataLayer;
using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
       

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.CreateAsync(product);
        }

        public async Task DeleteProductAsync(string productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if(product != null)
            {
            await _productRepository.DeleteAsync(productId);
            }
        }

        public Task<IEnumerable<Product>> GetAllProductAsync()
        {
            var products = _productRepository.GetAllAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(string productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return product;
        }

        public async Task UpdateProductAsync(Product product)
        {
                await _productRepository.UpdateAsync(product);
        }
    }
}
