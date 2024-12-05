using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace InsecureCryptographyLibrary
{
    public class InsecureCryptography
    {
        // 1. MD5 Hashing (Weak Cryptography)
        public static string HashPassword(string password)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(password, 16, 10000))
            {
                var salt = rfc2898.Salt;
                var hash = rfc2898.GetBytes(32); // 256-bit hash
                return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
            }
        }

        // 2. Storing sensitive data in plain text
        public static void StoreData(string data, string encryptionKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(encryptionKey);
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (FileStream fs = new FileStream("sensitiveData.txt", FileMode.Create))
                    {
                        fs.Write(aes.IV, 0, aes.IV.Length); // Store IV at the beginning
                        using (CryptoStream cs = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(data);
                        }
                    }
                }
            }
        }

        // 3. Weak Token Generation (Insecure Randomness)
        public static string GenerateToken()
        {
            byte[] tokenBytes = new byte[32]; // Use 256-bit tokens
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tokenBytes);
            }
            return Convert.ToBase64String(tokenBytes);
        }

        // 4. Using weak ciphers (DES)
        public static string EncryptData(string data, string encryptionKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(encryptionKey);
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    byte[] encrypted = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
                    return Convert.ToBase64String(aes.IV) + ":" + Convert.ToBase64String(encrypted);
                }
            }
        }

        // 5. Storing session tokens insecurely
        public static void StoreSessionToken(string token, string encryptionKey)
        {
            StoreData(token, encryptionKey); // Use the StoreData method to encrypt session tokens
        }
    }
}
