using Core.CarDealer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CarDealer
{
    public static class ExtensionMethods
    {
        public static async Task<PaginatedDTO<T>> Paginate<T>(this IQueryable<T> query,int page,int itemsPerPage)
        {
            int rowsToBeSkiped = itemsPerPage * page - itemsPerPage;

            int totalItems = query.Count();

            List<T> results = await query
                .Skip(rowsToBeSkiped)
                .Take(itemsPerPage)
                .ToListAsync();

            PaginatedDTO<T> paginated= new()
            {
                CurrentPage = page,
                TotalPages =
                Convert.ToInt16(Math.Ceiling((double)totalItems / itemsPerPage)),
                PrevPage = page - 1,
                NextPage = page + 1,
                Results = results
            };

            if (paginated.PrevPage <= 0)
                paginated.PrevPage = null;

            if (paginated.NextPage > paginated.TotalPages)
                paginated.NextPage = null;

            return paginated;

        }
    }
}
