using System.Security.Cryptography;
using System.Text;

namespace ApiUsuarios.Custom.Security
{
    public class HasherService : IHasherService
    {
        public string GenerateHasherPassword(string password)
        {
            using(SHA256 sha256=SHA256.Create())
            {
                byte[] bytes=sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder=new StringBuilder();

                for(int i=0; i<bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));

                }

                return builder.ToString();
            }
        }
    }
}
