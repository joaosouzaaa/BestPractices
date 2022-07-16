using BestPractices.Business.Interfaces.Pagination;
using BestPractices.Business.Settings.PaginationSettings;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Infra.Services
{
    public class PagingService<TEntity> : IPagingService<TEntity> where TEntity : class
    {
        public async Task<PageList<TEntity>> CreatePaginationAsync(IQueryable<TEntity> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PageList<TEntity>(items, count, pageNumber, pageSize);
        }
    }
}
