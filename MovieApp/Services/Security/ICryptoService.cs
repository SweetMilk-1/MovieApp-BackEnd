namespace MovieApp.Services.Security
{
    public interface ICryptoService
    {
        string GetHashFromString(string source);
    }
}
