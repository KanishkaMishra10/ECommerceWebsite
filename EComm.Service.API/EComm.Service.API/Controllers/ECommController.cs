using Microsoft.AspNetCore.Mvc;
using EComm.Core.dto.RequestModel;
using EComm.Service.Business;
using Microsoft.AspNetCore.Authorization;

namespace EComm.Service.API.Controllers
{
    public class ECommController : ControllerBase
    {
        private readonly EcommService _service;

        public ECommController(EcommService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/[controller]/GetProductsByTitle/{title}")]
       // [Authorize["Role"="Seller"]]

        public IActionResult GetProductsByTitle(string title)
        {
            var result = _service.GetProductsByTitle(title);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/GetAvailableProducts")]

        public IActionResult GetAvailableProducts()
        {
            var result = _service.GetAvailableProducts();
            return Ok(result);
        }

        [HttpGet]

        [Route("api/[controller]/GetProductsByCategoryId/{categoryId}")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var result = _service.GetProductsByCategoryId(categoryId);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/GetProductsById/{productId}")]
        public IActionResult GetProductsById(int productId)
        {
            var result = _service.GetProductsById(productId);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/GetCartDetails/{userId}")]
        public IActionResult GetCartDetails(int userId)
        {
            var result = _service.GetCartDetails(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/PlaceOrder/{userId}")]
        public IActionResult PlaceOrder(int userId)
        {
            _service.PlaceOrder(userId);
            return Ok();
        }

        [HttpPost]
        [Route("api/[controller]/AddNewProduct")]
        public IActionResult AddNewProduct(ProductRequestModel product)
        {
            _service.AddNewProduct(product);
            return Ok();
        }

        [HttpPost]
        [Route("api/[controller]/UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] int productId, int userId)
        {
            _service.UpdateProduct(productId, userId);
            return Ok();
        }

        [HttpPost]
        [Route("api/[controller]/AddToCart")]
        public IActionResult AddToCart(CartRequestModel product)
        {
            _service.AddToCart(product);
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/TotalCartValue/{userId}")]
        public IActionResult TotalCartValue(int userId)
        {
            var result = _service.TotalCartValue(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/[controller]/UpdateCart")]
        public IActionResult UpdateCart([FromBody] int productId, int userId, int quantity)
        {
            _service.UpdateCart(productId, userId, quantity);
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/GetAllOrders/{unserId}")]
        public IActionResult GetAllOrders(int userId)
        {
            var result = _service.GetAllOrders(userId);
            return Ok(result);
        }



        [HttpPost]
        [Route("api/[controller]/CancelOrder")]
        public IActionResult CancelOrder([FromBody] int orderId, int userId)
        {
            _service.CancelOrder(orderId, userId);
            return Ok();
        }

        [HttpPost]
        [Route("api/[controller]/RemoveCartItem")]
        public IActionResult RemoveCartItem([FromBody] int productId, int userId)
        {
            _service.RemoveCartItem(productId, userId);
            return Ok();
        }


        //[HttpGet]
        //[Route("api/[controller]/ShipmentDetails/{orderId}")]
        //public IActionResult GetShipmentDetails(int orderId)
        //{
        //    var result = _service.ShipmentDetails(orderId);
        //    return Ok(result);
        //}


    }
    

}
