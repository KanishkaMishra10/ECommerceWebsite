using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Service.Respository
{
    public interface IECommRepository
    {
        IEnumerable<ProductResponseModel> GetProductsByTitle(string title);

        IEnumerable<ProductResponseModel> GetAvailableProducts();

        IEnumerable<ProductResponseModel> GetProductsByCategoryId(int categoryId);

        IEnumerable<ProductResponseModel> GetProductsById(int productId);

        IEnumerable<CartResponseModel> GetCartDetails(int userId);
        public void PlaceOrder(int userId);

        public void AddNewProduct(ProductRequestModel product);     //for seller

        public void UpdateProduct(ProductRequestModel product);     //for seller

        public void AddToCart(int productId);

        public IEnumerable<decimal> TotalCartValue(int userId);

        public void UpdateCart(CartRequestModel cartRequestModel);

        //remove from cart
        public void RemoveCartItem(int productId);

        // Get all orders
        IEnumerable<string> GetAllOrders(int userId);   //order history
        
        // Cancel order
        public void CancelOrder(int orderId);
        
        //shiftment details
        public void ShipmentDetails(int orderId);

        //
        
    }
}
