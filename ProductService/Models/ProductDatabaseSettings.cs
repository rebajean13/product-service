namespace ProductService.Models
{
    public class ProductDatabaseSettings : IProductDatabaseSettings
    {
        public string PriceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProductDatabaseSettings
    {
        string PriceCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}