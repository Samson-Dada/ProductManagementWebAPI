using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManagementPlaftormAPI.Domain.Models;

namespace ProductManagementPlaftormAPI.DataLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ProductRepository(IOptions<DatabaseSettings> dbSettings )
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_dbSettings.Value.DatabaseName);
            _productCollection = mongoDatabase.GetCollection<Product>(_dbSettings.Value.ProductCollectionName); 

        }

        public async Task<bool> Productexists(string productId)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, productId );
                var count = await _productCollection.CountDocumentsAsync(filter);
            return count > 0;
        }


        public async Task CreateAsync(Product product)
        {
           await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _productCollection.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
           var products = await _productCollection.Find(_ => true).ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(string productId)
        {
           var product =  await _productCollection.Find(id => id.Id == productId).FirstOrDefaultAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
           var productId =await  _productCollection.Find(p => p.Id == product.Id).FirstOrDefaultAsync();
            await _productCollection.ReplaceOneAsync(p => p.Id  == productId.Id, product);
        }
    }
}
