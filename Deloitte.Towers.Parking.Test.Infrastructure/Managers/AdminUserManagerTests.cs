using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Infrastructure.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Test.Infrastructure.Logging.Managers
{
    [TestClass]
    public class AdminUserManagerTests
    {
        private Mock<IAdminUserRepository> _mock;

        [TestInitialize]
        public void Setup()
        {
            _mock = new Mock<IAdminUserRepository>();
        }


        [TestMethod]
        public void AdminUserManagerTest()
        {
            var controller = new AdminUserManager(_mock.Object);

            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(AdminUserManager));
        }
    }
}
