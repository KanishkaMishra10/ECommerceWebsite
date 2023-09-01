using EComm.Core.dto.ResponseModel;
using EComm.Core.dto.RequestModel;
using Ecomm.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Service.Repository
{
    public interface IECommRepository
    {
        IEnumerable<Product> GetProductsByTitle(string title);

        IEnumerable<Product> GetAvailableProducts();

        IEnumerable<Product> GetProductsByCategoryId(int categoryId);

        IEnumerable<Product> GetProductsById(int productId);

        IEnumerable<Cart> GetCartDetails(int userId);
        public void PlaceOrder(int userId);

        public void AddNewProduct(ProductRequestModel product);     //for seller

        public void UpdateProduct(int productId, int userId);     //for seller

        public void AddToCart(CartRequestModel productDetails);

        public IEnumerable<decimal> TotalCartValue(int userId);

        public void UpdateCart(int productId, int userId, int quantity);

        //remove from cart
        public void RemoveCartItem(int productId, int userId);

        // Get all orders
        public IEnumerable<string> GetAllOrders(int userId);   //order history

        // Cancel order
        public void CancelOrder(int orderId, int userId);
        
        //shiftment details
        public void ShipmentDetails(int orderId);

        //
        
    }
}
