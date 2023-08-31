using Ecomm.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EComm.Core.dto.ResponseModel;
using EComm.Core.dto.RequestModel;

namespace EComm.Service.Repository
{
    public class ECommRepository : IECommRepository
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
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                StockQuantity = product.StockQuantity,
                UserId = product.UserId,
                Discount = product.Discount,
                Price = product.Price,
                Color = product.Color,
                Description = product.Description
            });
            _context.SaveChanges();
        }

        public void AddToCart(CartRequestModel productDetails)
        {
            var prod = _context.Products.Find(productDetails.ProductId);
            if (prod != null)
            {

                _context.Add(new Cart
                {
                    ProductId = productDetails.ProductId,
                    UserId = productDetails.UserId,
                    Quantity = productDetails.Quantity
                });
                _context.SaveChanges();
            }

        }


        public void CancelOrder(int orderId, int userId)
        {
            _context.Orders.Where(x => x.OrderId == orderId && x.UserId == userId).FirstOrDefault().OderStatus = "Cancelled";
            _context.SaveChanges();
        }

        public IEnumerable<string> GetAllOrders(int userId)
        {
            List<string> listOfOrders = (from o in _context.Orders
                                         join oi in _context.OrderItems on o.OrderId equals oi.OrderId
                                         join b in _context.Products on oi.ProductId equals b.ProductId
                                         where o.UserId == userId && o.OderStatus != "Cancelled"
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


        public void RemoveCartItem(int productId, int userId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                var item = (from o in _context.Carts
                            where o.UserId == userId && o.ProductId == productId
                            select o).FirstOrDefault();
                if (item != null)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                }

            }
        }

        public void UpdateCart(int productId, int userId, int quantity)
        {
            _context.Update(new Cart
            {
                ProductId = productId,
                UserId = userId,
                Quantity = quantity });
            _context.SaveChanges();

        }


        public void ShipmentDetails(int orderId)
        {
            throw new NotImplementedException();

        }


        public IEnumerable<decimal> TotalCartValue(int userId)
        {
            throw new NotImplementedException();
        }


        public void UpdateProduct(int productId, int userId)         //used by seller --- wrong
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                var item = (from o in _context.Orders
                            where o.UserId == userId && o.ProductId == productId
                            select o).FirstOrDefault();

                _context.SaveChanges();
            }
        }

        public void PlaceOrder(int userId)
        {
            throw new NotImplementedException();
        }
        
    }
}
