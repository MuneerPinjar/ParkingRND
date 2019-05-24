using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Entities
{
    public class PageContainerCombined<T> : PageContainer<T>
    {
        public int UnreadCount { get; set; }

        public int FavoriteCount { get; set; }
    }
}
