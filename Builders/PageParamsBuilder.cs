using BestPractices.Business.Settings.PaginationSettings;

namespace Builders
{
    public class PageParamsBuilder
    {
        public static PageParamsBuilder NewObject()
        {
            return new PageParamsBuilder();
        }

        public PageParams DomainBuild()
        {
            return new PageParams
            {
                PageNumber = 1,
                PageSize = 10
            };
        }
    }
}
