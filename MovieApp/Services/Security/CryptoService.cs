using System.Security.Cryptography;
using System.Text;

namespace MovieApp.Services.Security
{
    public class CryptoService : ICryptoService
    {

        public string GetHashFromString(string source)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(source)));
        }
    }
}
