using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RulesEngine.Api.Controllers;
using RulesEngine.Contracts.Request;
using RulesEngine.Contracts.Response;
using RulesEngine.Process.Interface;
using System.Threading.Tasks;

namespace RulesEngine.Test
{
    
    [TestClass]
    public class MembershipControllerTest
    {
        [TestMethod]
        public async Task ActivateReturnsResultWhenModelStateContainsNoError()
        {
            var responseMock = new Mock<ActivateMembershipResponse>();
            var processMock = new Mock<IMembershipProcess>();
            var resultMock = new Mock<IActionResult>();
            var inputMock = new Mock<ActivateMembershipRequest>();

            var controllerMock = new Mock<MembershipController>(inputMock.Object, processMock.Object) { CallBase = true };
            processMock.Setup(h => h.ActivateMembership(It.IsAny<ActivateMembershipRequest>())).ReturnsAsync(responseMock.Object);
            var response = await controllerMock.Object.Activate(inputMock.Object, processMock.Object);

            //verify
            Assert.IsNotNull(response);
            Assert.AreSame(response, resultMock.Object);

        }
        [TestMethod]
        public async Task UpgradeReturnsResultWhenModelStateContainsNoError()
        {
            var responseMock = new Mock<UpgradeMembershipResponse>();
            var processMock = new Mock<IMembershipProcess>();
            var resultMock = new Mock<IActionResult>();
            var inputMock = new Mock<UpgradeMembershipRequest>();

            var controllerMock = new Mock<MembershipController>(inputMock.Object, processMock.Object) { CallBase = true };
            processMock.Setup(h => h.UpgradeMembership(It.IsAny<UpgradeMembershipRequest>())).ReturnsAsync(responseMock.Object);
            var response = await controllerMock.Object.Upgrade(inputMock.Object, processMock.Object);

            //verify
            Assert.IsNotNull(response);
            Assert.AreSame(response, resultMock.Object);

        }
    }
}
