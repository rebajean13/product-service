using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ProductService.Models;
using Xunit;

namespace ProductService.SystemTests
{
    public class ProductsApiTest
    {
        private readonly HttpClient httpClient;
        private const string testUrl = "http://localhost:5000";
        private const string validProductId = "13860428";

        public ProductsApiTest()
        {
            this.httpClient = new HttpClient();
        }

        [Fact]
        public async void GetAsync_ReturnsOk_WhenAllDataFound()
        {
            var result = await httpClient.GetAsync($"{testUrl}/products/{validProductId}");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var jobj = JObject.Parse(result.Content.ReadAsStringAsync().Result);

            Assert.Equal(validProductId, jobj["id"]);
            Assert.Equal("The Big Lebowski (Blu-ray)", jobj["name"]);
            Assert.Equal(13.49, jobj["current_price"]["value"]);
            Assert.Equal("USD", jobj["current_price"]["currency_code"]);
        }

        [Fact]
        public async void GetAsync_ReturnsOk_WithNoPrice_WhenNoPriceInDatastore()
        {
            var result = await httpClient.GetAsync($"{testUrl}/products/13860429");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var jobj = JObject.Parse(result.Content.ReadAsStringAsync().Result);

            Assert.Equal(13860429, jobj["id"]);
            Assert.Null(jobj["current_price"]);
        }

        [Fact]
        public async void GetAsync_ReturnsNotFound_ForUnknownProductId()
        {
            var result = await httpClient.GetAsync($"{testUrl}/products/15117729");

            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
