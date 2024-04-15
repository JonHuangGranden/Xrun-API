using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common.Helper
{
    public static class PasswordWithSaltHashHelper
    {
        public static string GenerateSalt(int size = 32)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public static bool ValidatePassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var hash = GenerateHash(enteredPassword, storedSalt);
            return hash == storedHash;
        }
    }
}
