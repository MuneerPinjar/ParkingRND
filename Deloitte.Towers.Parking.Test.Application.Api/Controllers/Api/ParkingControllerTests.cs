using Deloitte.Towers.Parking.Application.Api.Controllers;
using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Test.Application.Api.Controllers.Api
{
    [TestClass]
    public class ParkingControllerTests
    {
        private Mock<IParkingManager> _mock;


        [TestInitialize]
        public void Setup()
        {
            _mock = new Mock<IParkingManager>();
        }


        [TestMethod]
        public void ParkingControllerTest()
        {
            var controller = new ParkingController(_mock.Object);

            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(ParkingController));
        }
    }
}
