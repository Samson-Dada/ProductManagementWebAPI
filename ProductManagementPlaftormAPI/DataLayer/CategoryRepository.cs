using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.DataLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IOptions<DatabaseSettings> _dbSettings;
        private readonly IMongoCollection<Category> _categoriesCollection;

        public CategoryRepository(IMongoCollection<Category> mongoCollection,
            IOptions<DatabaseSettings> dbSettings)
        {
            _categoriesCollection = mongoCollection;
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

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            var categories  = await  _categoriesCollection.Find(_ =>).ToListAsync();
            return categories;
        }

        public Task GetProductByIdAsync(string categoryId)
        {
            
        }

        public Task UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
