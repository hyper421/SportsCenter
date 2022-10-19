using System.Security.Cryptography;
using System.Text;

namespace SportsCenter.Models.Hashing
{
    public class HashingPassword
    {
        //加鹽加密
        public string HashPassword(string password)
        {
            var hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedpassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedpassword);

        }
    }
}
