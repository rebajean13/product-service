namespace ProductService.Models
{
    public class ProductDetailsSettings : IProductDetailsSettings
    {
        public string MyRetailHost { get; set; }
    }

    public interface IProductDetailsSettings
    {
        string MyRetailHost { get; set; }
    }
}