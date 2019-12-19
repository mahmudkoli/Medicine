using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Common
{
    public static class EncryptDecrypt
    {
        public static string ToEncrypt(this string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                    .ComputeHash(Encoding.UTF8.GetBytes(value))
            );
        }

    }
}
