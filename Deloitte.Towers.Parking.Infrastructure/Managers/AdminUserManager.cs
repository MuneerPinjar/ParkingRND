using Deloitte.Towers.Parking.Domain.Contracts.Configurations;
using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Managers
{
    public class AdminUserManager : IAdminUserManager
    {
        private readonly IAdminUserRepository _adminUserRepository;


        public AdminUserManager(IAdminUserRepository adminUserRepository)
        {
            _adminUserRepository = adminUserRepository;
        }

        public async Task<int> AddAdminUserAsync(AdminUserAddDto adminUserAdd)
        {
            try
            {
         
                var result = await _adminUserRepository.AddAdminUserAsync(adminUserAdd);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task DeleteAdminUserAsync(AdminDeleteDto dto)
        {
            try
            {
                await _adminUserRepository.DeleteAdminUserAsync(dto);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<AdminUserDto> GetAdminUserByEmailAsync(string email)
        {
            try
            {
                var adminUser = await _adminUserRepository.GetAdminUserByEmailAsync(email);
                return adminUser;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<PageContainer<AdminUserEditDto>> GetAllAsync(int pageNumber, int rowsPerPage, string search)
        {
            try
            {
                var result = await _adminUserRepository.GetAllAsync(pageNumber,rowsPerPage,search);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
