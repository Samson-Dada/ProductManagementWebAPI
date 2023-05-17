using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.DataLayer
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task GetProductByIdAsync(string productId);
        Task CreateProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteAsync(string productId);
    }
}
