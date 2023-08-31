using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Core.dto.RequestModel
{
    public class ProductRequestModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int Discount { get; set; }

        public string Color { get; set; }
        public string Description { get; set; }
    }
}
