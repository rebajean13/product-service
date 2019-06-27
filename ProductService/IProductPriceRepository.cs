using ProductService.Models;

namespace ProductService
{
    public interface IProductPriceRepository
    {
        Price GetPrice(string ProductId);
    }
}