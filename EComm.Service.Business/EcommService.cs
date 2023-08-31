using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComm.Core.dto.ResponseModel;
using EComm.Core.dto.RequestModel;
using EComm.Service.Repository;
using AutoMapper;

namespace EComm.Service.Business
{
    public class EcommService
    {
        private readonly IECommRepository _repository;
        private readonly IMapper _mapper;

        public EcommService(IECommRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProductResponseModel> GetAvailableBooks()
        {
            var result = _repository.GetAvailableBooks();
            return _mapper.Map<IEnumerable<BookResponseModel>>(result);
        }

        IEnumerable<ProductResponseModel> GetProductsByTitle(string title)
        {
            var result = _repository.GetProductsByTitle(title);
            return _mapper.Map<IEnumerable<ProductResponseModel>>(result);
        }

        IEnumerable<ProductResponseModel> GetAvailableProducts()
        {
            var result = _repository.GetAvailableProducts();
            return _mapper.Map<IEnumerable<ProductResponseModel>>(result);
        }

        IEnumerable<ProductResponseModel> GetProductsByCategoryId(int categoryId)
        {
            var result = _repository.GetProductsByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<ProductResponseModel>>(result);
        }

        IEnumerable<ProductResponseModel> GetProductsById(int productId)
        {
            var result = _repository.GetProductsById(productId);
            return _mapper.Map<IEnumerable<ProductResponseModel>>(result);
        }

        IEnumerable<CartResponseModel> GetCartDetails(int userId)
        {
            var result = _repository.GetCartDetails(userId);
            return _mapper.Map<IEnumerable<CartResponseModel>>(result);
        }
        public void PlaceOrder(int userId);

        public void AddNewProduct(ProductRequestModel product);     //for seller

        public void UpdateProduct(int productId, int userId);     //for seller

        public void AddToCart(ProductRequestModel productRequestModel);

        public IEnumerable<decimal> TotalCartValue(int userId)
        {
            var result = _repository.TotalCartValue(userId);
            return _mapper.Map<IEnumerable<decimal>>(result);
        }

        public void UpdateCart(int productId, int userId, int quantity);

        //remove from cart
        public void RemoveCartItem(int productId, int userId);

        // Get all orders
        IEnumerable<string> GetAllOrders(int userId)   //order history
        {
        var result = _repository.GetAllOrders(userId);
            return _mapper.Map<IEnumerable<string>>(result);
        }

        // Cancel order
        public void CancelOrder(int orderId, int userId);

        //shiftment details
        public void ShipmentDetails(int orderId);

        //
    }
}
