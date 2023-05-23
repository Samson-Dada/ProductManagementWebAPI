using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.DataLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IOptions<DatabaseSettings> _dbSettings;
        private readonly IMongoCollection<Category> _categoriesCollection;

        public CategoryRepository(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;

            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _categoriesCollection = mongoDatabase.GetCollection<Category>(_dbSettings.Value.CategoryCollectionName);
        }

        public async Task CreateAsync(Category category)
        {
         await  _categoriesCollection.InsertOneAsync(category);
        }

        public async Task DeleteAsync(string categoryId)
        {
          await _categoriesCollection.DeleteOneAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories  = await  _categoriesCollection.Find(_ => true).ToListAsync();
            return categories;
        }

        public async Task<Category> GetByIdAsync(string categoryId)
        {
            var category = await _categoriesCollection.Find(c => c.Id == categoryId).FirstOrDefaultAsync();
            return category;
        }

        public async Task UpdateAsync(Category category)
        {
          await  _categoriesCollection.ReplaceOneAsync(c => c.Id == category.Id, category);
        }
    }
}
