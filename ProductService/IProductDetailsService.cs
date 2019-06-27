using System.Threading.Tasks;

namespace ProductService
{
    public interface IProductDetailsService
    {
        /// <summary>
        /// Gets the name of a product by its Id
        ///</summary>
        Task<string> GetProductNameById(string Id);
    }
}