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
   public class AuthorizeControllerTests
    {
        private Mock<IAdminUserManager> _mock;

        [TestInitialize]
        public void Setup()
        {
            _mock = new Mock<IAdminUserManager>();
        }


        [TestMethod]
        public void AuthorizeControllerTest()
        {
            var controller = new AuthorizeController(_mock.Object);

            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(AuthorizeController));
        }

    }
}
