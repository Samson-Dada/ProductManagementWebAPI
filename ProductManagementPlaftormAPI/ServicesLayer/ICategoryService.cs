using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(string categoryId);
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryByIdAsync(string categoryId);
    }
}
