using Microsoft.AspNetCore.Mvc;
using EComm.Core.dto.RequestModel;
using EComm.Service.Business;
using Microsoft.AspNetCore.Authorization;

namespace EComm.Service.API.Controllers
{
    
    public class ECommController : Controller
    {
        private readonly IEcommService _service;

        public ECommController(IEcommService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetProductsByTitle/{title}")]
        

        public IActionResult GetProductsByTitle(string title)
        {
            var result = _service.GetProductsByTitle(title);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAvailableProducts")]

        public IActionResult GetAvailableProducts()
        {
            var result = _service.GetAvailableProducts();
            return Ok(result);
        }

        [HttpGet]

        [Route("GetProductsByCategoryId/{categoryId}")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var result = _service.GetProductsByCategoryId(categoryId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductsById/{productId}")]
        public IActionResult GetProductsById(int productId)
        {
            if (productId < 0)
            {
                return BadRequest("Invalid Product Id");
            }

            var result = _service.GetProductsById(productId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCartDetails/{userId}")]
        public IActionResult GetCartDetails(int userId)
        {
            var result = _service.GetCartDetails(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("PlaceOrder/{userId}")]
        [Authorize(Roles = "Buyer")]
        public IActionResult PlaceOrder(int userId)
        {
            _service.PlaceOrder(userId);
            return Ok();
        }

        [HttpPost]
        [Route("AddNewProduct")]
        [Authorize(Roles = "Seller")]
        public IActionResult AddNewProduct(ProductRequestModel product)
        {
            _service.AddNewProduct(product);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateProduct")]
        [Authorize(Roles = "Seller")]
        public IActionResult UpdateProduct([FromBody] int productId, int userId)
        {
            _service.UpdateProduct(productId, userId);
            return Ok();
        }

        [HttpPost]
        [Route("AddToCart")]
        [Authorize(Roles = "Buyer")]
        public IActionResult AddToCart([FromBody] CartRequestModel product)
        {
            _service.AddToCart(product);
            return Ok();
        }

        [HttpGet]
        [Route("TotalCartValue/{userId}")]
        public IActionResult TotalCartValue(int userId)
        {
            var result = _service.TotalCartValue(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("UpdateCart")]
        [Authorize(Roles = "Seller")]
        public IActionResult UpdateCart([FromBody] int productId, int userId, int quantity)
        {
            _service.UpdateCart(productId, userId, quantity);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllOrders/{userId}")]
        public IActionResult GetAllOrders(int userId)
        {
            var result = _service.GetAllOrders(userId);
            return Ok(result);
        }



        [HttpPost]
        [Route("CancelOrder")]
        public IActionResult CancelOrder([FromBody] int orderId, int userId)
        {
            _service.CancelOrder(orderId, userId);
            return Ok();
        }

        [HttpPost]
        [Route("RemoveCartItem")]
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
