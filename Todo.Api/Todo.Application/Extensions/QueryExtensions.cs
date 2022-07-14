using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Contracts.Model;

namespace Todo.Application.Extensions
{
    public static class QueryExtensions
    {
        public static async Task<PagedModel<T>> ToPagedListAsync<T>(this IOrderedQueryable<T> queryable, int pageNumber, int pageSize)
        {
            var count = await queryable.CountAsync();
            int offset = (pageNumber - 1) * pageSize;
            var items = await queryable.Skip(offset).Take(pageSize).ToArrayAsync();
            return new PagedModel<T>(items, count, pageNumber, pageSize);
        }
    }
}
