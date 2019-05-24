using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Domain.Entities;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Repositories
{
    public class AdminUserRepository : BaseRepository, IAdminUserRepository
    {
        private const string GetAdminUserByEmailSpName = "[spAdminUserGetByEmail]";
        private const string AddAdminUserSpName = "[spAdminUserAdd]";
        private const string GetAllSpName = "[spAdminUserGetAll]";
        private const string DeleteAdminUserSpName = "[spAdminUserDelete]";
        private const string GetAdminUserByIdSpName = "[spAdminUserGetById]";

        public async Task<int> AddAdminUserAsync(AdminUserAddDto adminUserAdd)
        {
            try
            {
                var args = new Dictionary<string, object>
            {
                {"@Email", adminUserAdd.Email},
                {"@IsActive", adminUserAdd.IsActive},
                {"@CreatedBy", adminUserAdd.CreatedBy},
                {"@CreatedDate", DateTime.UtcNow},
                {"@LastModificationDate", DateTime.UtcNow},
                {"@FirstName", adminUserAdd.FirstName },
                {"@LastName", adminUserAdd.LastName },
                {"@ModifiedBy", adminUserAdd.ModifiedBy },
            };

                var newAdminUserId = await ExecuteScalarAsync<int>(AddAdminUserSpName, args);
                return newAdminUserId;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task DeleteAdminUserAsync(AdminDeleteDto dto)
        {
            try
            {
                var args = new Dictionary<string, object>
            {
                {"@Email", dto.Email},
                {"@ModifiedBy", dto.ModifiedBy}

            };

                await ExecuteNonQueryAsync(DeleteAdminUserSpName, args);
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
                var mapper = new AdminUserDtoMapper();

                var args = new Dictionary<string, object>
            {
                {"@Email", email}
            };

                var result = await ExecuteReaderAsync(GetAdminUserByEmailSpName, mapper, args);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            throw new NotImplementedException();
        }

        public async Task<AdminUserEditDto> GetAdminUserByIdAsync(int id)
        {
            try
            {
                var mapper = new AdminUserEditDtoMapper();

                var args = new Dictionary<string, object>
            {
                {"@Id", id}
            };

                var result = await ExecuteReaderAsync(GetAdminUserByIdSpName, mapper, args);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
            throw new NotImplementedException();
        }

        public async Task<PageContainer<AdminUserEditDto>> GetAllAsync(int pageNumber, int rowsPerPage, string search)
        {
            try
            {
                var mapper = new AdminUserEditDtoListMapper();
                var result = await ExecuteReaderAsync(GetAllSpName, mapper);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
