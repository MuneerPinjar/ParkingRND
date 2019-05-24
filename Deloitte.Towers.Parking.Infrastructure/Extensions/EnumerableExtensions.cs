using Deloitte.Towers.Parking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Deloitte.Towers.Parking.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static PageContainer<T> ToPageContainer<T>(this IEnumerable<T> collection, int totalCount)
        {
            return new PageContainer<T>()
            {
                Items = collection,
                TotalCount = totalCount
            };
        }

        public static PageContainerCombined<T> ToPageContainer<T>(this IEnumerable<T> collection, int totalCount, int unreadCount, int favoriteCount)
        {
            return new PageContainerCombined<T>()
            {
                Items = collection,
                TotalCount = totalCount,
                UnreadCount = unreadCount,
                FavoriteCount = favoriteCount
            };
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> value, int countOfEachPart)
        {
            int cnt = value.Count() / countOfEachPart;
            List<IEnumerable<T>> result = new List<IEnumerable<T>>();
            for (int i = 0; i <= cnt; i++)
            {
                IEnumerable<T> newPart = value.Skip(i * countOfEachPart).Take(countOfEachPart).ToArray();
                if (newPart.Any())
                    result.Add(newPart);
                else
                    break;
            }

            return result;
        }
    }
}
