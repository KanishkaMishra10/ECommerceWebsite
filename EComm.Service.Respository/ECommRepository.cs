using Ecomm.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Service.Respository
{
    internal class ECommRepository : IECommRepository
    {
        private readonly ECommContext _context;

        public ECommRepository(ECommContext context)
        {
            _context = context;
        }

        public void AddNewProduct(ProductRequestModel product)


        {
            _context.Add(new Product
            {
                ProductId = order.BookId,
                Quantity = order.Quantity,
                IsBorrowed = order.isBorrowed
            });
            _context.SaveChanges();
        }

        public void AddToCart(int productId)
        {
            throw new NotImplementedException();
        }

        public void CancelOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllOrders(int userId)
        {
            List<string> listOfOrders = (from o in _context.Orders
                                               join oi in _context.OrderItems on o.OrderId equals oi.OrderId
                                               join b in _context.Products on oi.ProductId equals b.ProductId
                                               where o.UserId == userId
                                               select b.ProductName).ToList();
            return listOfOrders;
        }


        public IEnumerable<ProductResponseModel> GetAvailableProducts()
        {
            List<Product> listOfAvailableProducts = _context.Products.Where(x => x.StockQuantity > 0).ToList();
            return (IEnumerable<ProductResponseModel>)listOfAvailableProducts;
        }

        public IEnumerable<CartResponseModel> GetCartDetails(int userId)
        {
            List<Cart> cartDetails = _context.Carts.Where(x => x.UserId == userId).ToList();
            return (IEnumerable<CartResponseModel>)cartDetails;
        }

        public IEnumerable<ProductResponseModel> GetProductsByCategoryId(int categoryId)
        {
            List<Product> listOfProducts = _context.Products.Where(b => b.CategoryId == categoryId).ToList();
            return (IEnumerable<ProductResponseModel>)listOfProducts;
        }

        public IEnumerable<ProductResponseModel> GetProductsById(int productId)
        {
            List<Product> products = _context.Products.Where(b => b.ProductId == productId).ToList();
            return (IEnumerable<ProductResponseModel>)products;
        }

        public IEnumerable<ProductResponseModel> GetProductsByTitle(string title)
        {
            List<Product> products = _context.Products.Where(a => a.ProductName == title).ToList();
            return (IEnumerable<ProductResponseModel>)products;
        }

        public void PlaceOrder(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCartItem(int cartId)
        {
            throw new NotImplementedException();
        }

        public void ShipmentDetails(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<decimal> TotalCartValue(int userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCart(CartRequestModel cartRequestModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductRequestModel product)
        {
            throw new NotImplementedException();
        }
    }
}
