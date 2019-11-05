using _24102019_uwp.Data;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24102019_uwp.Models;

namespace _24102019_uwp.Business
{
    public class Login
    {
        public static bool IsLogin { get; set; }

        public static bool login(string userID, string password)
        {
            if (!int.TryParse(userID, out int a)) return false;

            using(var db = new ApplicationDBContext())
            {
                var user = db.Users.SingleOrDefault(p => p.UserID == int.Parse(userID));

                if (user == null) return false;

                var hash = GetHashString(password + user.Salt);

                if (hash == user.Password)
                {
                    IsLogin = true;
                    User = user;
                    return true;
                }
            }

            return false;
        }

        public static User User { get; set; }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static void Logout()
        {
            User = null;
            IsLogin = false;
        }
    }
}
