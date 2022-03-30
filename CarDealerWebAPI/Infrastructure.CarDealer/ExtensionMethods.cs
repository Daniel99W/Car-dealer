using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query,int page,int itemsPerPage)
        {
            int rowsToBeSkiped = itemsPerPage * page - itemsPerPage;

            return query
                .Skip(rowsToBeSkiped)
                .Take(itemsPerPage);
        }
    }
}
