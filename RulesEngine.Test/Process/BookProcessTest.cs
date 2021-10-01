using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RulesEngine.Process;
using RulesEngine.Process.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Test.Process
{
    [TestClass]
    public class BookProcessTest
    {
        [TestMethod]
        public void ConstructorAssignsProperties()
        {
            var agentPaymentProcessMock = new Mock<IAgentPaymentProcess>();

            var process = new BookProcess(agentPaymentProcessMock.Object);
            Assert.IsNotNull(process);
        }
        [TestMethod]
        public void ConstructorThrowsExceptionWhenAgentPaymentProcessDependencyIsNull()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => new BookProcess(null));
            Assert.IsNotNull(exception);
        }
    }
}
