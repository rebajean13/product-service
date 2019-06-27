using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ProductService.Models
{
    public class Price
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [JsonIgnore]
        public ObjectId Id { get; set; } 

        [BsonElement("ProductId")]
        [JsonIgnore]
        public string ProductId { get; set; }

        [BsonElement("Value")]
        [BsonRepresentation(BsonType.Decimal128, AllowTruncation=true)]
        [JsonProperty("value", NullValueHandling=NullValueHandling.Ignore)]
        public decimal Value { get; set; }

        [BsonElement("CurrencyCode")]
        [JsonProperty("currency_code", NullValueHandling=NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }
    }
}