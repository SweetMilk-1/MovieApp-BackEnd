namespace MovieApp.Infrastucture.Exceptions
{
    /// <summary>
    /// Исключение, по которому можно различать системные и мои исключения
    /// </summary>
    public class AppException : Exception
    {
        public string Name { get; }
        public AppException(string message) : base(message)
        {
            Name = GetType().Name;
        }
    }
}
