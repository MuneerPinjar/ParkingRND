using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Managers
{
    public interface IAdminUserManager
    {
        Task<AdminUserDto> GetAdminUserByEmailAsync(string email);
        Task<int> AddAdminUserAsync(AdminUserAddDto adminUserAdd);
        Task<PageContainer<AdminUserEditDto>> GetAllAsync(int pageNumber, int rowsPerPage, string search);
        Task DeleteAdminUserAsync(AdminDeleteDto dto);
    
    }
}
