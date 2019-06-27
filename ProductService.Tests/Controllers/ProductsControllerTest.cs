using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ProductService.Controllers;
using ProductService.Models;

namespace ProductService.Tests
{
    public class ProductsControllerTest
    {
        Mock<IProductDetailsService> mockProductDetailsService = new Mock<IProductDetailsService>();
        Mock<IProductPriceRepository> mockProductPriceRepository = new Mock<IProductPriceRepository>();

        [Fact]
        public async void GetAsync_ReturnsOK_WithProductDetails()
        {
            var subject = new ProductsController(mockProductDetailsService.Object, mockProductPriceRepository.Object);
            var price = new Price { Value=45.50M, CurrencyCode="EUR" };

            mockProductDetailsService.Setup(service => service.GetProductNameById(It.IsAny<string>())).Returns(Task.FromResult("foo"));
            mockProductPriceRepository.Setup(repo => repo.GetPrice(It.IsAny<string>())).Returns(price);

            var result = await subject.GetAsync("1234");
            var ok = (OkObjectResult)result;
            var resultObj = (Product)ok.Value;

            Assert.Equal("1234", resultObj.Id);
            Assert.Equal("foo", resultObj.Name);
            Assert.Equal(price, resultObj.CurrentPrice);
        }

        // More Tests here
    }
}