using System.ComponentModel.DataAnnotations;
using SuperMarketManagementSystem.Services;

namespace SuperMarketManagementSystem.Models
{
    public class product
    {
        [Key]
        public int productId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; }
    }

}
