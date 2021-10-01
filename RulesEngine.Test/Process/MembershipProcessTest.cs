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
    public class MembershipProcessTest
    {
        [TestMethod]
        public void ConstructorAssignsProperties()
        {
            var sendEmailProcessMock = new Mock<ISendEmailProcess>();
            
            var process = new MembershipProcess(sendEmailProcessMock.Object);
            Assert.IsNotNull(process);
        }
        [TestMethod]
        public void ConstructorThrowsExceptionWhenSendEmailProcessDependencyIsNull()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => new MembershipProcess(null));
            Assert.IsNotNull(exception);
        }
    }
}
