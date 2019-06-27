using Newtonsoft.Json;

namespace ProductService.Models
{
    public class Product{
       
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("current_price", NullValueHandling=NullValueHandling.Ignore)]
        public Price CurrentPrice { get; set; }
    }
}