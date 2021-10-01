using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RulesEngine.Api.Controllers;
using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using RulesEngine.Process.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Test
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public async Task GeneratePackingSlipWhenModelStateContainsNoError()
        {
            var responseMock = new Mock<BuyProductResponse>();
            var processMock = new Mock<IProductProcess>();
            var resultMock = new Mock<IActionResult>();
            var inputMock = new Mock<BuyProductRequest>();

            var controllerMock = new Mock<ProductController>(inputMock.Object, processMock.Object) { CallBase = true };
            processMock.Setup(h => h.GeneratePackingSlip(It.IsAny<BuyProductRequest>())).ReturnsAsync(responseMock.Object);
            var response = await controllerMock.Object.GeneratePackingSlip(inputMock.Object, processMock.Object);

            //verify
            Assert.IsNotNull(response);
            Assert.AreSame(response, resultMock.Object);

        }
    }
}
