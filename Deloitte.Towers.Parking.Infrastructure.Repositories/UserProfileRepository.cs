using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.Web.EndUser;
using Deloitte.Towers.Parking.Domain.Entities;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {

        private const string UserProfileInsert = "[spAddUser]";
        private const string UpdateUserProfile = "[spUpdateUserProfile]";
        private const string GetAllSpName = "[spUserProfileGetAllByPgNumber]";

        public async Task<int> AddUserProfileAsync(UserProfileDto dto)
        {
            try
            {
                var args = new Dictionary<string, object>
                 {
                {"@FirstName", dto.FirstName},
                {"@LastName", dto.LastName},
                {"@DisplayName", dto.DisplayName},
                {"@VehiclePreference", dto.VehicleType},
                {"@LastLogin", DateTime.UtcNow},
                {"@EmailId", dto.Email},
                {"@CreatedBy", dto.CreatedBy},
                {"@CreatedDate", dto.Created },
                {"@LastModificationDate", dto.LastModificationDate },
                {"@LastModifiedBy", dto.LastModifiedBy },             
                {"@GeofencingNotification", dto.GeoFencingNotification },
                {"@FullParkingNotification", dto.ParkingFullNotification },
                {"@LocationTracking", dto.LocationTracking },
                {"@CampusId", dto.Campus },
                {"@MonArrivalTime", dto.MondayArrivalTime },
                {"@TueArrivalTime", dto.TuesdayArrivalTime },
                {"@WedArrivalTime", dto.WedArrivalTime },
                {"@ThuArrivalTime", dto.ThuArrivalTime },
                {"@FriArrivalTime", dto.FriArrivalTime },
                {"@SatArrivalTime", dto.SatArrivalTime },
                {"@SunArrivalTime", dto.SunArrivalTime }
            };

                var newUserId = await ExecuteScalarAsync<int>(UserProfileInsert, args);
                return newUserId;
            }
            catch (Exception ex)
           {

                throw ex;
            }

        }

        public async Task<PageContainer<UserProfileDto>> GetAllAsync(int pageNumber, int rowsPerPage, string search)
        {

            try
            {
                var args = new Dictionary<string, object>
                 {
                {"@pageNumber", pageNumber},
                {"@rowsPerPage", rowsPerPage},
                {"@search", search}

            };
                var mapper = new UserProfileDtoListMapper();
                var result = await ExecuteReaderAsync(GetAllSpName, mapper, args);
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
                var args = new Dictionary<string, object>
            {
                {"@EmailId", dto.Email},
                {"@VehiclePreference", dto.VehicleType},
                {"@ModifiedBy", dto.ModifiedBy},
                {"@GeofencingNotification", dto.GeoFencingNotification},
                {"@FullParkingNotification", dto.ParkingFullNotification},
                {"@LocationTracking", dto.LocationTracking},
                {"@LastModificationDate", dto.LastModificationDate},
                {"@CampusId", dto.Campus},
                {"@IsActive", dto.Status},
                {"@IsDeleted", dto.IsDeleted},
                {"@MonArrivalTime", dto.MondayArrivalTime},
                {"@TueArrivalTime", dto.TuesdayArrivalTime },
                {"@WedArrivalTime", dto.WedArrivalTime },
                {"@ThuArrivalTime", dto.ThuArrivalTime},
                {"@FriArrivalTime", dto.FriArrivalTime },
                {"@SatArrivalTime", dto.SatArrivalTime },
                {"@SunArrivalTime", dto.SunArrivalTime}
            };

                await ExecuteNonQueryAsync(UpdateUserProfile, args);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
