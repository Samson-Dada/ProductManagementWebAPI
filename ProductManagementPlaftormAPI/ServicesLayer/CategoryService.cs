using ProductManagementPlaftormAPI.DataLayer;
using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(Category category)
        {
          await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteCategoryByIdAsync(string categoryId)
        {
           await _categoryRepository.DeleteAsync(categoryId);
        }

        public Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            var categories = _categoryRepository.GetAllAsync();
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(string categoryId)
        {
           var category = await _categoryRepository.GetByIdAsync(categoryId);
            return category;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
