using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.DataLayer
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task GetByIdAsync(string categoryId);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(string categoryId);
    }
}
