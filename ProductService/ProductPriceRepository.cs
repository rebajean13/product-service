using System;
using MongoDB.Driver;
using ProductService.Models;

namespace ProductService
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly IMongoCollection<Price> prices;

        public ProductPriceRepository(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            prices = database.GetCollection<Price>(settings.PriceCollectionName);
        }

        public Price GetPrice(string ProductId) => prices.Find<Price>(price => price.ProductId == ProductId).SingleOrDefault();
    }
}