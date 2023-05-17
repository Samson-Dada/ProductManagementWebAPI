using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.DataLayer
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task GetByIdAsync(string productId);
        Task CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(string productId);
    }
}
