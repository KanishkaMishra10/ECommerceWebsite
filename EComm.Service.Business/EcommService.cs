using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComm.Core.dto.ResponseModel;
using EComm.Core.dto.RequestModel;
using EComm.Service.Repository;
using Ecomm.Service.Domain.Models;
using AutoMapper;
using System.Net;
using Ecomm.Service.Domain.Models;

namespace EComm.Service.Business
{
    public class EcommService : IEcommService
    {
        private readonly IECommRepository _repository;
        private readonly IMapper _mapper;

        public EcommService(IECommRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Product> GetProductsByTitle(string title)
        {
            var result = _repository.GetProductsByTitle(title);
            return _mapper.Map<IEnumerable<Product>>(result);
        }

        public IEnumerable<Product> GetAvailableProducts()
        {
            var result = _repository.GetAvailableProducts();
            return _mapper.Map<IEnumerable<Product>>(result);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var result = _repository.GetProductsByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<Product>>(result);
        }

       public IEnumerable<Product> GetProductsById(int productId)
        {
            var result = _repository.GetProductsById(productId);
            return _mapper.Map<IEnumerable<Product>>(result);
        }

        public IEnumerable<Cart> GetCartDetails(int userId)
        {
            var result = _repository.GetCartDetails(userId);
            return _mapper.Map<IEnumerable<Cart>>(result);
        }
        public void PlaceOrder(int userId)
        {
            _repository.PlaceOrder( userId);
        }

        public void AddNewProduct(ProductRequestModel product)    //for seller
        {             _repository.AddNewProduct(product);
               }

        public void UpdateProduct(int productId, int userId)     //for seller
        { _repository.UpdateProduct(productId, userId);}

        public void AddToCart(CartRequestModel product)
        {
            _repository.AddToCart(product);
        }

        public IEnumerable<decimal> TotalCartValue(int userId)
        {
            var result = _repository.TotalCartValue(userId);
            return _mapper.Map<IEnumerable<decimal>>(result);
        }

        public void UpdateCart(int productId, int userId, int quantity)
        {
            _repository.UpdateCart(productId, userId, quantity);
        }

        //remove from cart
        public void RemoveCartItem(int productId, int userId)
        {
            _repository.RemoveCartItem(productId, userId);
        }

        // Get all orders
       public IEnumerable<string> GetAllOrders(int userId)   //order history
        {
        var result = _repository.GetAllOrders(userId);
            return _mapper.Map<IEnumerable<string>>(result);
        }

        // Cancel order
        public void CancelOrder(int orderId, int userId)
        {
            _repository.CancelOrder(orderId, userId);
        }

        //shiftment details
        public void ShipmentDetails(int orderId)
        {
            _repository.ShipmentDetails(orderId);
        }

       
        




        //
    }
}
