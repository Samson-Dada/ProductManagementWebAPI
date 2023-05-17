using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task GetCategoryByIdAsync(string categoryId);
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryByIdAsync(string categoryId);
    }
}
