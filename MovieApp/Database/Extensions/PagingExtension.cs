namespace MovieApp.Database.Extensions
{
    public static class PagingExtension 
    {
        public static IQueryable<T> Paging<T>(
            this IQueryable<T> query,
            int page,
            int perPage)
        {
            return query
                .Skip(perPage * (page - 1))
                .Take(perPage);
        }
    }
}
