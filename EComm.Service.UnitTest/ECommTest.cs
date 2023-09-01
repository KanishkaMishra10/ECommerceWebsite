using Ecomm.Service.Domain.Models;
using EComm.Core.dto.RequestModel;
using EComm.Core.dto.ResponseModel;
using EComm.Service.API.Controllers;
using EComm.Service.Business;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EComm.Service.UnitTest
{
    [TestClass]
    public class ECommTest
    {
        public ECommController ecommController;
        public Mock<IEcommService> mockEcommService;
        public ECommTest()
        {
            mockEcommService = new Mock<IEcommService>();
            ecommController = new ECommController(mockEcommService.Object);
        }


        [TestMethod]
        public void GetAllProductById_should_return_ok()
        {
            int productId = 1;
            List<Product> products = new();
            mockEcommService.Setup(x => x.GetProductsById(productId)).Returns(products);
            var result = ecommController.GetProductsById(productId);
            var actual = result as OkObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(200, actual.StatusCode);
        }

      
  

        [TestMethod]

        public void GetAllProductById_should_return_badrequest()
        {
            int productId = -1;
            List<Product> products = new();
            mockEcommService.Setup(x => x.GetProductsById(productId)).Returns(products);
            var result = ecommController.GetProductsById(productId);
            var actual = result as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, actual.StatusCode);
        }

        //[TestMethod]
        //public void GetProductsByCategory_should_return_ok()
        //{
        //    var category = 2;
        //    List<ProductResponseModel> products = new();
        //    mockservice.Setup(x => x.GetProductsByCategory(category)).Returns(products);
        //    var result = controller.GetProductsByCategory(category);
        //    var actual = result as OkObjectResult;



        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(200, actual.StatusCode);
        //}
    }
}