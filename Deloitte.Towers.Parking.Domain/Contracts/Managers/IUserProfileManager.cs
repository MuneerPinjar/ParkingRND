using Deloitte.Towers.Parking.Domain.Dto.Web.EndUser;
using Deloitte.Towers.Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Managers
{
    public interface IUserProfileManager
    {
        Task<int> AddUserProfileAsync(UserProfileDto dto);
        Task UpdateUserProfileAsync(UserProfileDto dto);
        Task<PageContainer<UserProfileDto>> GetAllAsync(int pageNumber, int rowsPerPage,string search);

    }
}
