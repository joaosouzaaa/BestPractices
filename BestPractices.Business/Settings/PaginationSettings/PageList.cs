namespace BestPractices.Business.Settings.PaginationSettings
{
    public class PageList<TEntity>
    {
        public List<TEntity> Result { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PageList() { }

        public PageList(List<TEntity> items, int count, int pageNumber, int pageSize)
        {
            Result = items;

            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Result.AddRange(items);
        }
    }
}
