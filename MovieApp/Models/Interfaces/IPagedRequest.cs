namespace MovieApp.Models.Interfaces
{
    public interface IPagedRequest
    {
        public string? Search { get;  }
        public int PerPage { get;  } 
        public int Page { get; }
    }
}
