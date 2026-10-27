using EmployeeAccess.Application.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAccess.Persistence.Extensions
{
    internal static class QueryableExtensions
    {
        public static async Task<PaginationResponse<T>> ToPagedListAsync<T>(this IQueryable<T> queryable,
                                                                            PaginationRequest request,
                                                                            CancellationToken cancellationToken)
        {
            int totalCount = await queryable.CountAsync(cancellationToken);

            List<T> items = await queryable.Skip((request.PageNumber - 1) * request.PageSize)
                                           .Take(request.PageSize)
                                           .ToListAsync(cancellationToken);

            return PaginationResponse<T>.Create(items, totalCount, request);
        }
    }
}
