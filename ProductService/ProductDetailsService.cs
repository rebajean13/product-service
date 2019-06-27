using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ProductService.Models;

namespace ProductService
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly HttpClient httpClient;
        private readonly IProductDetailsSettings productDetailsSettings;

        public ProductDetailsService(IProductDetailsSettings productDetailsSettings) {
            this.httpClient = new HttpClient();
            this.productDetailsSettings = productDetailsSettings;
        }

        public async Task<string> GetProductNameById(string Id)
        {
            var result = await httpClient.GetAsync($"{productDetailsSettings.MyRetailHost}/v2/pdp/tcin/{Id}");
            var status = result.StatusCode;

            switch (status)
            {
                case HttpStatusCode.NotFound: 
                    return null;
                case HttpStatusCode.OK:
                    return this.ParseName(result);
                default:
                    throw new Exception($"Error retrieving product details for Id={Id}. ErrorCode: {result.StatusCode}");
            }
        }

        private string ParseName(HttpResponseMessage result)
        {
            try 
            {
                var jobject  = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                var name = (string)jobject.SelectToken("product.item.product_description.title");

                return name;
            } 
            catch (Exception)
            {
                return null;
            }
        }
    }
}