public void InsecureBase64Encryption(string data)
{
   byte[] key = Encoding.UTF8.GetBytes("A5D1F6E7B3C8A9F1"); 
   byte[] iv = Encoding.UTF8.GetBytes("1234567890ABCDEF");

   using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                    }
                }
                var encryptedData = Convert.ToBase64String(ms.ToArray());
                Console.WriteLine($"AES Encrypted Data: {encryptedData}");
            }
    }
}
