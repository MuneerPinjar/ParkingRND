using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Infrastructure.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Test.Infrastructure.Managers
{
    [TestClass]
    class VccIntergrationManagerTests
    {
        private Mock<IVccIntegrationRepository> _mock;

        [TestInitialize]
        public void Setup()
        {
            _mock = new Mock<IVccIntegrationRepository>();
        }


        [TestMethod]
        public void VccIntergrationManagerTest()
        {
            var controller = new VccIntergrationManager(_mock.Object);

            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(VccIntergrationManager));
        }
    }
}
