using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    /// <summary>
    /// Controllor for product information
    /// </summary>
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDetailsService productDetailsService;
        private readonly IProductPriceRepository productPriceRepository;
        public ProductsController(IProductDetailsService productDetailsService, IProductPriceRepository productPriceRepository)
        {
            this.productDetailsService = productDetailsService;
            this.productPriceRepository = productPriceRepository;
        }

        /// <summary>
        /// Gets Product Information
        /// </summary>
        /// <param name="id">The product id</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var productName = await this.productDetailsService.GetProductNameById(id);
            var productPrice = this.productPriceRepository.GetPrice(id);

            if (productName == null)
            {
                return NotFound();
            }

            return Ok(new Product
            {
                Id = id,
                Name = productName,
                CurrentPrice = productPrice,
            });
        }
    }
}