using BestPractices.Business.Settings.PaginationSettings;

namespace UnitTests.Builders.Helpers
{
    public class Utils
    {
        public static PageList<TEntity> PageListBuilder<TEntity>(List<TEntity> pageListEntities)
        {
            return new PageList<TEntity>
            {
                CurrentPage = 1,
                PageSize = 10,
                Result = pageListEntities,
                TotalCount = pageListEntities.Count,
                TotalPages = 1
            };
        }
    }
}
