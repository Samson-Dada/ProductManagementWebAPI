using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task GetProductByIdAsync(string productId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(string productId);
    }
}
