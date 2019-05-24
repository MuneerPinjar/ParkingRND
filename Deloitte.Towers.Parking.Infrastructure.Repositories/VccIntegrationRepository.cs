using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.VccData;
using Deloitte.Towers.Parking.Infrastructure.Repositories.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Repositories
{
    public class VccIntegrationRepository : BaseRepository, IVccIntegrationRepository
    {
        protected readonly string ConnectionString;

        private const string VccCampusParking = "[uspVccCampusParking]";
        private const string VccAreaParking = "[uspVccAreaParking]";

        public VccIntegrationRepository() : this(ConnectionStringHelper.ConnectionStringName)
        {
        }

        protected VccIntegrationRepository(string connectionStringName)
        {
            ConnectionString = ConnectionStringHelper.GetConnectionString(connectionStringName);
        }

        public void Save(VCCRootData vccRootData)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            for (int i = 0; i < vccRootData.Carparks.Count; i++)
            {
                #region sp1

                //var argsVccCampusParking = new Dictionary<string, object>
                //{
                //    {"@AsOf", vccRootData.AsOf},
                //    {"@ParkId", vccRootData.Carparks[i].Id},
                //    {"@ParkName", vccRootData.Carparks[i].Name},
                //    {"@Usable", vccRootData.Carparks[i].TotalsDetailed.All.Usable},
                //    {"@Vacant", vccRootData.Carparks[i].TotalsDetailed.All.Vacant},
                //    {"@Occupied", vccRootData.Carparks[i].TotalsDetailed.All.Occupied },
                //    {"@Unknown", vccRootData.Carparks[i].TotalsDetailed.All.Unknown},
                //};

                //var resultVccCampusParking = ExecuteScalarAsync<int>(VccCampusParking, argsVccCampusParking);

                //for (int j = 0; j < vccRootData.Carparks[i].Areas.Count; j++)
                //{
                //    var argsVccCampusAreaParking = new Dictionary<string, object>
                //    {
                //        {"@AsOf", vccRootData.AsOf},
                //        {"@AreaId", vccRootData.Carparks[i].Areas[j].Id},
                //        {"@AreaName", vccRootData.Carparks[i].Areas[j].Name},
                //        {"@Usable", vccRootData.Carparks[i].Areas[j].TotalsDetailed.All.Usable},
                //        {"@Vacant", vccRootData.Carparks[i].Areas[j].TotalsDetailed.All.Vacant},
                //        {"@Occupied", vccRootData.Carparks[i].Areas[j].TotalsDetailed.All.Occupied },
                //        {"@Unknown", vccRootData.Carparks[i].Areas[j].TotalsDetailed.All.Unknown},
                //        {"@ParkId", vccRootData.Carparks[i].Id},
                //        {"@ParkName", vccRootData.Carparks[i].Name},
                //    };

                //    var resultVccAreaParking = ExecuteScalarAsync<int>(VccAreaParking, argsVccCampusAreaParking);
                //}

                #endregion

                // Save Vcc Campus Parking
                SqlCommand cmdVccCampusParking = new SqlCommand("uspVccCampusParking", connection);
                cmdVccCampusParking.Parameters.Add("@AsOf", System.Data.SqlDbType.DateTime).Value = vccRootData.AsOf;
                cmdVccCampusParking.Parameters.Add("@ParkId", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].Id;
                cmdVccCampusParking.Parameters.Add("@ParkName", System.Data.SqlDbType.VarChar).Value = vccRootData.Carparks[i].Name;
                cmdVccCampusParking.Parameters.Add("@Usable", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].TotalsDetailed.All.Usable;
                cmdVccCampusParking.Parameters.Add("@Vacant", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].TotalsDetailed.All.Vacant;
                cmdVccCampusParking.Parameters.Add("@Occupied", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].TotalsDetailed.All.Occupied;
                cmdVccCampusParking.Parameters.Add("@Unknown", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].TotalsDetailed.All.Unknown;

                connection.Open();
                cmdVccCampusParking.CommandType = System.Data.CommandType.StoredProcedure;
                cmdVccCampusParking.ExecuteNonQuery();
                connection.Close();

                // Save Vcc Area Parking

                for (int j = 0; j < vccRootData.Carparks[i].Areas.Count; j++)
                {
                    SqlCommand cmdVccAreaParking = new SqlCommand("uspVccAreaParking", connection);
                    cmdVccAreaParking.Parameters.Add("@AsOf", System.Data.SqlDbType.DateTime).Value = vccRootData.AsOf;
                    cmdVccAreaParking.Parameters.Add("@AreaId", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].Areas[j].Id;
                    cmdVccAreaParking.Parameters.Add("@AreaName", System.Data.SqlDbType.VarChar).Value = vccRootData.Carparks[i].Areas[j].Name;
                    cmdVccAreaParking.Parameters.Add("@Usable", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].Areas[j].TotalsDetailed.All.Usable;
                    cmdVccAreaParking.Parameters.Add("@Vacant", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].Areas[j].TotalsDetailed.All.Vacant;
                    cmdVccAreaParking.Parameters.Add("@Occupied", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].Areas[j].TotalsDetailed.All.Occupied;
                    cmdVccAreaParking.Parameters.Add("@Unknown", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].Areas[j].TotalsDetailed.All.Unknown;
                    cmdVccAreaParking.Parameters.Add("@ParkId", System.Data.SqlDbType.Int).Value = vccRootData.Carparks[i].Id;
                    cmdVccAreaParking.Parameters.Add("@ParkName", System.Data.SqlDbType.VarChar).Value = vccRootData.Carparks[i].Name;

                    connection.Open();
                    cmdVccAreaParking.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdVccAreaParking.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
