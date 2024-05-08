using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Services
{
    internal static class PasswordHasher
    {
        public static string Hash_MD5(this string password)
        {
            // Create hash
            var data = Encoding.ASCII.GetBytes(password);
            new MD5CryptoServiceProvider().ComputeHash(data);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(data);

            // Format hash with extra information
            return string.Format("$MYHASH$V1${0}${1}", 3, base64Hash);
        }

        public static string Hash_SHA1(this string password)
        {
            // Create hash
            var data = Encoding.ASCII.GetBytes(password);
            new SHA1CryptoServiceProvider().ComputeHash(data);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(data);

            // Format hash with extra information
            return string.Format("$MYHASH$V1${0}${1}", 3, base64Hash);
        }
    }
}
