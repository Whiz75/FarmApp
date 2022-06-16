

namespace FarmApp.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class Products
    {
        [JsonProperty("productId")]
        public long ProductId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }
    }
}
