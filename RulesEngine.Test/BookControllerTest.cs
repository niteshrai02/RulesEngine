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
    public class BookControllerTest
    {
        [TestMethod]
        public async Task GenerateDuplicatePackingSlipWhenModelStateContainsNoError()
        {
            var responseMock = new Mock<BuyBookResponse>();
            var processMock = new Mock<IBookProcess>();
            var resultMock = new Mock<IActionResult>();
            var inputMock = new Mock<BuyBookRequest>();

            var controllerMock = new Mock<BookController>(inputMock.Object, processMock.Object) { CallBase = true };
            processMock.Setup(h => h.GenerateDuplicatePackingSlip(It.IsAny<BuyBookRequest>())).ReturnsAsync(responseMock.Object);
            var response = await controllerMock.Object.GenerateDuplicatePackingSlip(inputMock.Object, processMock.Object);

            //verify
            Assert.IsNotNull(response);
            Assert.AreSame(response, resultMock.Object);

        }
    }
}
