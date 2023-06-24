using Newtonsoft.Json; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ShoppingCart.Models
{
    [Table("Stocks")]
    public class Stock
    {
        [Key]
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("pricePerUnit")]
        public double PricePerUnit { get; set; }

        [JsonProperty("stockQty")]
        public int StockQty { get; set; }
    }
}
