namespace MovieApp.Models.Interfaces
{
    public interface IPagedRequest
    {
        public int PerPage { get;  } 
        public int Page { get; }
    }
}
