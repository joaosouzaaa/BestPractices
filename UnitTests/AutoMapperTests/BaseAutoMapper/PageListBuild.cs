using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.Business.Settings.PaginationSettings;

namespace UnitTests.AutoMapperTests.BaseAutoMapper
{
    public abstract class PageListBuild<TEntityFrom, TEntityTo>
        where TEntityTo : class
        where TEntityFrom : class
    {
        protected PageList<TEntityFrom> PageList;

        public PageListBuild()
        {
            PageListData();

            AutoMapperHandler.Inicialize();
        }

        private void PageListData()
        {
            PageList = new PageList<TEntityFrom>
            {
                CurrentPage = 1,
                PageSize = 10,
                Result = new List<TEntityFrom>(),
                TotalCount = 10,
                TotalPages = 3
            };
        }

        [Fact]
        public async Task PageListFrom_To_PageListTo()
        {
            var entity = PageList.MapTo<PageList<TEntityFrom>, PageList<TEntityTo>>();

            Assert.Equal(entity.Result.Count, PageList.Result.Count);
            Assert.Equal(entity.TotalCount, PageList.TotalCount);
            Assert.Equal(entity.TotalPages, PageList.TotalPages);
            Assert.Equal(entity.PageSize, PageList.PageSize);
            Assert.Equal(entity.CurrentPage, PageList.CurrentPage);
        }
    }
}
