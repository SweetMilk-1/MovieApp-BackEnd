namespace MovieApp.Models
{
    public class PagedListWrapper<T>
    {
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int PerPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
