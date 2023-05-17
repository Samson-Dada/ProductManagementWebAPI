using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.DataLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly IOptions<DatabaseSettings> _dbSettings;
        private readonly IMongoCollection<Product> _productCollection;


        public ProductRepository(IOptions<DatabaseSettings> dbSettings, 
            IMongoCollection<Product> productCollection)
        {
            _dbSettings = dbSettings;
            _productCollection = productCollection;
            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _productCollection = mongoDatabase.GetCollection<Product>(_dbSettings.Value.ProductCollectionName); 

        }

        public async Task CreateProductAsync(Product product)
        {
           await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string productId)
        {
          await _productCollection.DeleteOneAsync(id => id.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
           var products = await _productCollection.Find(_ => true).ToListAsync();
            return products;
        }

        public async Task GetProductByIdAsync(string productId)
        {
           await  _productCollection.Find(id => id.Id == productId).FirstOrDefaultAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
           var productId =await  _productCollection.Find(p => p.Id == product.Id).FirstOrDefaultAsync();
            await _productCollection.ReplaceOneAsync(p => p.Id  == productId.Id, product);
        }
    }
}
