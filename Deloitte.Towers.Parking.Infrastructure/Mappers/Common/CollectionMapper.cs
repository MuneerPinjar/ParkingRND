using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Mappers.Common
{
    public class CollectionMapper<TEntity, TRowMapper> : IMapper<List<TEntity>>
        where TEntity : class
        where TRowMapper : IRowMapper<TEntity>, new()
    {
        public async Task<List<TEntity>> MapAsync(DbDataReader reader)
        {
            var collection = new List<TEntity>();

            var rowMapper = new TRowMapper();
            while (await reader.ReadAsync())
            {
                var x = rowMapper.Map(reader);
                collection.Add(x);
            }

            return collection;
        }
    }
}
