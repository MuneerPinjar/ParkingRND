using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.Web.EndUser;
using Deloitte.Towers.Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Managers
{
    public class UserProfileManager : IUserProfileManager
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileManager(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public async Task<int> AddUserProfileAsync(UserProfileDto dto)
        {
            try
            {
                var result = await _userProfileRepository.AddUserProfileAsync(dto);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<PageContainer<UserProfileDto>> GetAllAsync(int pageNumber, int rowsPerPage, string search)
        {
            try
            {
                var result = await _userProfileRepository.GetAllAsync(pageNumber, rowsPerPage, search);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateUserProfileAsync(UserProfileDto dto)
        {
            try
            {
                dto.LastModificationDate = DateTime.UtcNow;
                await _userProfileRepository.UpdateUserProfileAsync(dto);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
