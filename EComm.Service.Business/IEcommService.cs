using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComm.Core.dto.ResponseModel;
using EComm.Core.dto.RequestModel;

namespace EComm.Service.Business
{
    public interface IEcommService
    {
        IEnumerable<ProductResponseModel> GetProductsByTitle(string title);

        IEnumerable<ProductResponseModel> GetAvailableProducts();

        IEnumerable<ProductResponseModel> GetProductsByCategoryId(int categoryId);

        IEnumerable<ProductResponseModel> GetProductsById(int productId);

        IEnumerable<CartResponseModel> GetCartDetails(int userId);
        public void PlaceOrder(int userId);

        public void AddNewProduct(ProductRequestModel product);     //for seller

        public void UpdateProduct(ProductRequestModel product);     //for seller

        public void AddToCart(CartRequestModel cartRequestModel);

        public IEnumerable<decimal> TotalCartValue(int userId);

        public void UpdateCart(int productId, int userId, int quantity);

        //remove from cart
        public void RemoveCartItem(int productId, int userId);

        // Get all orders
        IEnumerable<string> GetAllOrders(int userId);   //order history

        // Cancel order
        public void CancelOrder(int orderId, int userId);

        //shiftment details
        public void ShipmentDetails(int orderId);
    }
}
