using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Mappers.Common
{
    public interface IRowMapper<out T> where T : class
    {
        T Map(IDataReader reader);
    }
}
