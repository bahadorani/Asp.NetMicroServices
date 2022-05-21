using Catalog.APl.Data;
using Catalog.APl.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.APl.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _ctx;
        public ProductRepository(ICatalogContext context)
        {
            _ctx = context;
        }
        public async Task CreateProduct(Product product)
        {
             await _ctx.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            DeleteResult result = await _ctx.Products.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            return await _ctx.Products.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _ctx.Products.Find(p=>true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, category);
            return await _ctx.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            FilterDefinition<Product> filter=Builders<Product>.Filter.Eq(p => p.Name,name);
            return await _ctx.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result = await _ctx.Products.ReplaceOneAsync(filter: g=>g.Id == product.Id,replacement:product);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
