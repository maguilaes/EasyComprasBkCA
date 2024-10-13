using Domain.Repository;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Repository
{
    public class HashService : IHashService
    {
        public string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);
            return clave;
        }

        public string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
            //using (var hashAlgorithm = SHA256.Create())
            //{
            //    var byteValue = Encoding.UTF8.GetBytes(texto);
            //    var byteHash = hashAlgorithm.ComputeHash(byteValue);
            //    return Convert.ToBase64String(byteHash);
            //}
        }
    }
}
