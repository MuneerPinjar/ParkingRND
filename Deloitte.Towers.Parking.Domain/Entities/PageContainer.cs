using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Entities
{
    public class PageContainer<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int ItemsCount => Items?.Count() ?? 0;

        public int TotalCount { get; set; }
    }
}
