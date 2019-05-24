using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deloitte.Towers.Parking.Application.Api.Controllers;
using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Domain.Entities;
using System.Web.Http.Results;
using System.Web.Http;

namespace Deloitte.Towers.Parking.Test.Application.Api.Controllers.Api
{
    [TestClass]
    public class AdminUserControllerTests
    {
        private Mock<IAdminUserManager> _mock;

        [TestInitialize]
        public void Setup()
        {
            _mock = new Mock<IAdminUserManager>();
        }


        [TestMethod]
        public void AdminUserControllerTest()
        {
            var controller = new AdminUserController(_mock.Object);

            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(AdminUserController));
        }


        [TestMethod]
        public async Task AddAdminUserAsyncTest()
        {
            _mock.Setup(p => p.AddAdminUserAsync(GetTestAdminUserDto())).ReturnsAsync(new int());
            var controller = new AdminUserController(_mock.Object);
            var actionResult = await controller.AddAdminUserAsync(GetTestAdminUserDto());
            var contentResult = actionResult as OkNegotiatedContentResult<BaseApiResponse>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsInstanceOfType(contentResult, typeof(OkNegotiatedContentResult<BaseApiResponse>));
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(IHttpActionResult));
            Assert.IsInstanceOfType(contentResult.Content.Data, typeof(int));

        }

        [TestMethod]
        public async Task GetAllAdminUserAsyncTest()
        {
            _mock.Setup(p => p.GetAllAsync(1, 10, null)).ReturnsAsync(new PageContainer<AdminUserEditDto>());
            var controller = new AdminUserController(_mock.Object);
            var actionResult = await controller.GetAllAsync(1, 10, null);
            var contentResult = actionResult as OkNegotiatedContentResult<BaseApiResponse>;

            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(IHttpActionResult));
            Assert.IsNotNull(contentResult);
            Assert.IsInstanceOfType(contentResult, typeof(OkNegotiatedContentResult<BaseApiResponse>));
            Assert.IsNotNull(contentResult.Content);
            Assert.IsInstanceOfType(contentResult.Content.Data, typeof(PageContainer<AdminUserEditDto>));
        }

        [TestMethod]
        public async Task GetAdminUserByEmaildAsyncTest()
        {
            _mock.Setup(p => p.GetAdminUserByEmailAsync("test@email.com")).ReturnsAsync(new AdminUserDto());
            var controller = new AdminUserController(_mock.Object);
            var actionResult = await controller.GetAdminUserByEmaildAsync("test@email.com");
            var contentResult = actionResult as OkNegotiatedContentResult<BaseApiResponse>;

            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(IHttpActionResult));
            Assert.IsNotNull(contentResult);
            Assert.IsInstanceOfType(contentResult, typeof(OkNegotiatedContentResult<BaseApiResponse>));
            Assert.IsNotNull(contentResult.Content);
            Assert.IsInstanceOfType(contentResult.Content.Data, typeof(AdminUserDto));
        }

        [TestMethod]
        public async Task DeleteAdminUserAsyncTest()
        {
            _mock.Setup(p => p.DeleteAdminUserAsync(GetTestAdminDeleteDto()));
            var controller = new AdminUserController(_mock.Object);
            var actionResult = await controller.DeleteAdminUserAsync(GetTestAdminDeleteDto());
            var contentResult = actionResult as OkNegotiatedContentResult<BaseApiResponse>;


            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(IHttpActionResult));
            Assert.IsNotNull(contentResult);
            Assert.IsInstanceOfType(contentResult, typeof(OkNegotiatedContentResult<BaseApiResponse>));
            Assert.IsNotNull(contentResult.Content);
        }

        private static AdminUserAddDto GetTestAdminUserDto()
        {
            return new AdminUserAddDto
            {
                FirstName = "test first name",
                LastName = "test last name",
                Email = "testemail@test.com",               
                CreatedDate = DateTime.UtcNow,
                IsActive =true,
                IsDeleted = false,
                LastModificationDate = DateTime.UtcNow,
                ModifiedBy = "Test Modified By",
                Status = "Test status",
                CreatedBy = "Test created by"
            };
        }

        private static AdminDeleteDto GetTestAdminDeleteDto()
        {
            return new AdminDeleteDto
            {
                Email = "test@email.com",
                ModifiedBy = "Test Modified by"
            };
        }

    }
}
