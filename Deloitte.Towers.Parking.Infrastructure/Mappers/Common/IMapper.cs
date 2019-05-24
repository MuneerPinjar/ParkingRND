using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Mappers.Common
{
    public interface IMapper<T> where T : class
    {
        Task<T> MapAsync(DbDataReader reader);
    }
}
